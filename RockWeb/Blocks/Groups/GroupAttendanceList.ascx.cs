﻿// <copyright>
// Copyright 2013 by the Spark Development Network
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;

using Newtonsoft.Json;

using Rock;
using Rock.Attribute;
using Rock.Data;
using Rock.Model;
using Rock.Security;
using Rock.Web.Cache;
using Rock.Web.UI;
using Rock.Web.UI.Controls;

namespace RockWeb.Blocks.Groups
{
    [DisplayName( "Group Attendance List" )]
    [Category( "Groups" )]
    [Description( "Lists all the scheduled occurrences for a given group." )]

    [LinkedPage( "Detail Page" )]
    public partial class GroupAttendanceList : RockBlock
    {
        #region Private Variables

        private RockContext _rockContext = null;
        private Group _group = null;
        private bool _canView = false;

        #endregion

        #region Control Methods

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            _rockContext = new RockContext();

            _group = new GroupService( _rockContext ).Get( PageParameter( "GroupId" ).AsInteger() );
            if ( _group != null && _group.IsAuthorized( Authorization.VIEW, CurrentPerson ) )
            {
                _group.LoadAttributes( _rockContext );
                _canView = true;

                gOccurrences.DataKeyNames = new string[] { "OccurrenceStartDateTime" };
                gOccurrences.ShowActionRow = false;
                gOccurrences.AllowPaging = false;
                gOccurrences.AllowSorting = false;
                gOccurrences.GridRebind += gOccurrences_GridRebind;

                // make sure they have Auth to edit the block OR edit to the Group
                bool canEditBlock = IsUserAuthorized( Authorization.EDIT ) || _group.IsAuthorized( Authorization.EDIT, this.CurrentPerson );
                gOccurrences.Actions.ShowAdd = canEditBlock;
                gOccurrences.IsDeleteEnabled = canEditBlock;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            pnlContent.Visible = _canView;

            if ( !Page.IsPostBack && _canView )
            {
                BindGrid();
            }
        }

        #endregion

        #region GroupMembers Grid

        /// <summary>
        /// Handles the Edit event of the gOccurrences control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RowEventArgs" /> instance containing the event data.</param>
        protected void gOccurrences_Edit( object sender, RowEventArgs e )
        {
            var qryParams = new Dictionary<string, string> { 
                { "GroupId", _group.Id.ToString() },
                { "Occurrence", ( (DateTime)e.RowKeyValue ).ToString( "o" ) } };
            NavigateToLinkedPage( "DetailPage", qryParams );
        }

        /// <summary>
        /// Handles the GridRebind event of the gOccurrences control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected void gOccurrences_GridRebind( object sender, EventArgs e )
        {
            BindGrid();
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Binds the group members grid.
        /// </summary>
        protected void BindGrid()
        {
            if ( _group != null )
            {
                var occurrences = new GroupService( _rockContext ).GetGroupOccurrences( _group );

                gOccurrences.DataSource = occurrences.OrderByDescending( o => o.OccurrenceStartDateTime ).ToList();
                gOccurrences.DataBind();
            }
        }


        #endregion


    }
    
}