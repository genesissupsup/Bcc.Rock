//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// Data Transfer Object for Workflow object
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class WorkflowDto : DtoSecured<WorkflowDto>
    {
        /// <summary />
        [DataMember]
        public int WorkflowTypeId { get; set; }

        /// <summary />
        [DataMember]
        public string Name { get; set; }

        /// <summary />
        [DataMember]
        public string Description { get; set; }

        /// <summary />
        [DataMember]
        public string Status { get; set; }

        /// <summary />
        [DataMember]
        public bool IsProcessing { get; set; }

        /// <summary />
        [DataMember]
        public DateTime? ActivatedDateTime { get; set; }

        /// <summary />
        [DataMember]
        public DateTime? LastProcessedDateTime { get; set; }

        /// <summary />
        [DataMember]
        public DateTime? CompletedDateTime { get; set; }

        /// <summary>
        /// Instantiates a new DTO object
        /// </summary>
        public WorkflowDto ()
        {
        }

        /// <summary>
        /// Instantiates a new DTO object from the entity
        /// </summary>
        /// <param name="workflow"></param>
        public WorkflowDto ( Workflow workflow )
        {
            CopyFromModel( workflow );
        }

        /// <summary>
        /// Creates a dictionary object.
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, object> ToDictionary()
        {
            var dictionary = base.ToDictionary();
            dictionary.Add( "WorkflowTypeId", this.WorkflowTypeId );
            dictionary.Add( "Name", this.Name );
            dictionary.Add( "Description", this.Description );
            dictionary.Add( "Status", this.Status );
            dictionary.Add( "IsProcessing", this.IsProcessing );
            dictionary.Add( "ActivatedDateTime", this.ActivatedDateTime );
            dictionary.Add( "LastProcessedDateTime", this.LastProcessedDateTime );
            dictionary.Add( "CompletedDateTime", this.CompletedDateTime );
            return dictionary;
        }

        /// <summary>
        /// Creates a dynamic object.
        /// </summary>
        /// <returns></returns>
        public override dynamic ToDynamic()
        {
            dynamic expando = base.ToDynamic();
            expando.WorkflowTypeId = this.WorkflowTypeId;
            expando.Name = this.Name;
            expando.Description = this.Description;
            expando.Status = this.Status;
            expando.IsProcessing = this.IsProcessing;
            expando.ActivatedDateTime = this.ActivatedDateTime;
            expando.LastProcessedDateTime = this.LastProcessedDateTime;
            expando.CompletedDateTime = this.CompletedDateTime;
            return expando;
        }

        /// <summary>
        /// Copies the model property values to the DTO properties
        /// </summary>
        /// <param name="model">The model.</param>
        public override void CopyFromModel( IEntity model )
        {
            base.CopyFromModel( model );

            if ( model is Workflow )
            {
                var workflow = (Workflow)model;
                this.WorkflowTypeId = workflow.WorkflowTypeId;
                this.Name = workflow.Name;
                this.Description = workflow.Description;
                this.Status = workflow.Status;
                this.IsProcessing = workflow.IsProcessing;
                this.ActivatedDateTime = workflow.ActivatedDateTime;
                this.LastProcessedDateTime = workflow.LastProcessedDateTime;
                this.CompletedDateTime = workflow.CompletedDateTime;
            }
        }

        /// <summary>
        /// Copies the DTO property values to the entity properties
        /// </summary>
        /// <param name="model">The model.</param>
        public override void CopyToModel ( IEntity model )
        {
            base.CopyToModel( model );

            if ( model is Workflow )
            {
                var workflow = (Workflow)model;
                workflow.WorkflowTypeId = this.WorkflowTypeId;
                workflow.Name = this.Name;
                workflow.Description = this.Description;
                workflow.Status = this.Status;
                workflow.IsProcessing = this.IsProcessing;
                workflow.ActivatedDateTime = this.ActivatedDateTime;
                workflow.LastProcessedDateTime = this.LastProcessedDateTime;
                workflow.CompletedDateTime = this.CompletedDateTime;
            }
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public static class WorkflowDtoExtension
    {
        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Workflow ToModel( this WorkflowDto value )
        {
            Workflow result = new Workflow();
            value.CopyToModel( result );
            return result;
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<Workflow> ToModel( this List<WorkflowDto> value )
        {
            List<Workflow> result = new List<Workflow>();
            value.ForEach( a => result.Add( a.ToModel() ) );
            return result;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<WorkflowDto> ToDto( this List<Workflow> value )
        {
            List<WorkflowDto> result = new List<WorkflowDto>();
            value.ForEach( a => result.Add( a.ToDto() ) );
            return result;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static WorkflowDto ToDto( this Workflow value )
        {
            return new WorkflowDto( value );
        }

    }
}