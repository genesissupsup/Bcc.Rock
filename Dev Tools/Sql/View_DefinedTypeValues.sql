/* List DefinedTypeValues*/
SELECT t.Category
    ,t.Id AS [Type ID]
    ,t.NAME AS [DefinedType.Name]
    ,v.Id AS [Value ID]
    ,v.Value AS Value
    ,v.Description
    ,cast((
            SELECT a.NAME
                ,av.Value
                ,a.Guid [Attribute.Guid]
                ,av.Guid [AttributeValue.Guid]
            FROM AttributeValue av
            JOIN Attribute a ON av.AttributeId = a.Id
            JOIN EntityType et ON a.EntityTypeId = et.Id
            WHERE et.NAME = 'Rock.Model.DefinedValue'
                AND av.EntityId = v.Id
            FOR XML PATH('Attribute')
                ,root('root')
            ) AS XML) [AttributeValues]
    ,t.Guid [DefinedType.Guid]
    ,v.Guid [DefinedValue.Guid]
FROM DefinedValue AS v
INNER JOIN DefinedType AS t ON t.Id = v.DefinedTypeId
ORDER BY [t].[Category]
    ,[t].[Name]
    ,[v].[Order]
    ,[v].[Value]
