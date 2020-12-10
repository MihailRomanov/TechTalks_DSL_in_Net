<?xml version="1.0" encoding="utf-8"?>
<Dsl xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="baa4afbf-ed87-4c68-b177-6dd2f3acd851" Description="Description for EPAM.NHModelingLanguage.NHModelingLanguage" Name="NHModelingLanguage" DisplayName="NHModelingLanguage" Namespace="EPAM.NHModelingLanguage" ProductName="NHModelingLanguage" CompanyName="EPAM" PackageGuid="ac482944-ef91-4a4c-9e92-0278bf2f4d02" PackageNamespace="EPAM.NHModelingLanguage" xmlns="http://schemas.microsoft.com/VisualStudio/2005/DslTools/DslDefinitionModel">
  <Classes>
    <DomainClass Id="97799dd1-d93c-4c2f-bacc-fcf4a36f94f0" Description="Description for EPAM.NHModelingLanguage.NHModel" Name="NHModel" DisplayName="NHModel" Namespace="EPAM.NHModelingLanguage">
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Entity" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>NHModelHasEntities.Entities</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="205b3bdf-94ad-43f3-a9af-d520a1a20ace" Description="Description for EPAM.NHModelingLanguage.Entity" Name="Entity" DisplayName="Entity" Namespace="EPAM.NHModelingLanguage">
      <Properties>
        <DomainProperty Id="c5871ad9-a942-4754-be67-aa815eab5fa2" Description="Description for EPAM.NHModelingLanguage.Entity.Name" Name="Name" DisplayName="Name" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
      <ElementMergeDirectives>
        <ElementMergeDirective>
          <Index>
            <DomainClassMoniker Name="Property" />
          </Index>
          <LinkCreationPaths>
            <DomainPath>EntityHasProperties.Properties</DomainPath>
          </LinkCreationPaths>
        </ElementMergeDirective>
      </ElementMergeDirectives>
    </DomainClass>
    <DomainClass Id="ad3169a6-62fb-47f6-b185-9f93f5048837" Description="Description for EPAM.NHModelingLanguage.Property" Name="Property" DisplayName="Property" Namespace="EPAM.NHModelingLanguage">
      <Properties>
        <DomainProperty Id="72cda865-300b-4471-9665-bdeaab3b616e" Description="Description for EPAM.NHModelingLanguage.Property.Name" Name="Name" DisplayName="Name" IsElementName="true">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="bd0cb726-12a5-4081-9ab8-c14b6abfb5f2" Description="Description for EPAM.NHModelingLanguage.Property.Type" Name="Type" DisplayName="Type">
          <Type>
            <DomainEnumerationMoniker Name="TypeEnum" />
          </Type>
        </DomainProperty>
        <DomainProperty Id="d63b2a0d-1b38-4ea0-a69b-d7c1930ee913" Description="Description for EPAM.NHModelingLanguage.Property.Display Name" Name="DisplayName" DisplayName="Display Name" Kind="Calculated" IsBrowsable="false">
          <Type>
            <ExternalTypeMoniker Name="/System/String" />
          </Type>
        </DomainProperty>
      </Properties>
    </DomainClass>
  </Classes>
  <Relationships>
    <DomainRelationship Id="9eda0661-f5e6-4e67-9a59-be5a6c6e0b47" Description="Description for EPAM.NHModelingLanguage.NHModelHasEntities" Name="NHModelHasEntities" DisplayName="NHModel Has Entities" Namespace="EPAM.NHModelingLanguage" IsEmbedding="true">
      <Source>
        <DomainRole Id="a6b1340f-9030-4230-b5b8-d4a6a12f7100" Description="Description for EPAM.NHModelingLanguage.NHModelHasEntities.NHModel" Name="NHModel" DisplayName="NHModel" PropertyName="Entities" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Entities">
          <RolePlayer>
            <DomainClassMoniker Name="NHModel" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="4e466b8a-445d-4fbf-af1d-41ee3bbc3764" Description="Description for EPAM.NHModelingLanguage.NHModelHasEntities.Entity" Name="Entity" DisplayName="Entity" PropertyName="NHModel" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="NHModel">
          <RolePlayer>
            <DomainClassMoniker Name="Entity" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="fae53cd7-45ba-4f32-8321-d04cf03a08c8" Description="Description for EPAM.NHModelingLanguage.EntityHasProperties" Name="EntityHasProperties" DisplayName="Entity Has Properties" Namespace="EPAM.NHModelingLanguage" IsEmbedding="true">
      <Source>
        <DomainRole Id="0750cb35-73db-46b3-a5d0-71436db3d4bb" Description="Description for EPAM.NHModelingLanguage.EntityHasProperties.Entity" Name="Entity" DisplayName="Entity" PropertyName="Properties" PropagatesCopy="PropagatesCopyToLinkAndOppositeRolePlayer" PropertyDisplayName="Properties">
          <RolePlayer>
            <DomainClassMoniker Name="Entity" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="6fe93a27-a821-4438-986b-e05d828ea37c" Description="Description for EPAM.NHModelingLanguage.EntityHasProperties.Property" Name="Property" DisplayName="Property" PropertyName="Entity" Multiplicity="One" PropagatesDelete="true" PropertyDisplayName="Entity">
          <RolePlayer>
            <DomainClassMoniker Name="Property" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
    <DomainRelationship Id="e8574d96-4785-4cfa-a868-14020741031b" Description="Description for EPAM.NHModelingLanguage.EntityInheritedParent" Name="EntityInheritedParent" DisplayName="Entity Inherited Parent" Namespace="EPAM.NHModelingLanguage">
      <Source>
        <DomainRole Id="7a2853bc-e78e-4cc6-aa4e-d992539bfa6a" Description="Description for EPAM.NHModelingLanguage.EntityInheritedParent.SourceEntity" Name="SourceEntity" DisplayName="Source Entity" PropertyName="Parent" Multiplicity="ZeroOne" PropertyDisplayName="Parent">
          <RolePlayer>
            <DomainClassMoniker Name="Entity" />
          </RolePlayer>
        </DomainRole>
      </Source>
      <Target>
        <DomainRole Id="bbee86fd-e200-47bb-ad2b-fa68952db93c" Description="Description for EPAM.NHModelingLanguage.EntityInheritedParent.TargetEntity" Name="TargetEntity" DisplayName="Target Entity" PropertyName="Children" PropertyDisplayName="Children">
          <RolePlayer>
            <DomainClassMoniker Name="Entity" />
          </RolePlayer>
        </DomainRole>
      </Target>
    </DomainRelationship>
  </Relationships>
  <Types>
    <ExternalType Name="DateTime" Namespace="System" />
    <ExternalType Name="String" Namespace="System" />
    <ExternalType Name="Int16" Namespace="System" />
    <ExternalType Name="Int32" Namespace="System" />
    <ExternalType Name="Int64" Namespace="System" />
    <ExternalType Name="UInt16" Namespace="System" />
    <ExternalType Name="UInt32" Namespace="System" />
    <ExternalType Name="UInt64" Namespace="System" />
    <ExternalType Name="SByte" Namespace="System" />
    <ExternalType Name="Byte" Namespace="System" />
    <ExternalType Name="Double" Namespace="System" />
    <ExternalType Name="Single" Namespace="System" />
    <ExternalType Name="Guid" Namespace="System" />
    <ExternalType Name="Boolean" Namespace="System" />
    <ExternalType Name="Char" Namespace="System" />
    <DomainEnumeration Name="TypeEnum" Namespace="EPAM.NHModelingLanguage" Description="Description for EPAM.NHModelingLanguage.TypeEnum">
      <Literals>
        <EnumerationLiteral Description="Description for EPAM.NHModelingLanguage.TypeEnum.String" Name="String" Value="" />
        <EnumerationLiteral Description="Description for EPAM.NHModelingLanguage.TypeEnum.Int32" Name="Int32" Value="" />
        <EnumerationLiteral Description="Description for EPAM.NHModelingLanguage.TypeEnum.Decimal" Name="Decimal" Value="" />
      </Literals>
    </DomainEnumeration>
  </Types>
  <Shapes>
    <CompartmentShape Id="bc33c5c6-7b4a-43d8-9105-0f3da6cc7bc0" Description="Description for EPAM.NHModelingLanguage.EntityShape" Name="EntityShape" DisplayName="Entity Shape" Namespace="EPAM.NHModelingLanguage" FixedTooltipText="Entity Shape" InitialHeight="0.45" Geometry="RoundedRectangle">
      <ShapeHasDecorators Position="InnerTopRight" HorizontalOffset="0" VerticalOffset="0">
        <ExpandCollapseDecorator Name="ExpandCollapseDecorator" DisplayName="Expand Collapse Decorator" />
      </ShapeHasDecorators>
      <ShapeHasDecorators Position="InnerTopCenter" HorizontalOffset="0" VerticalOffset="0">
        <TextDecorator Name="NameDecorator" DisplayName="Name Decorator" DefaultText="NameDecorator" />
      </ShapeHasDecorators>
      <Compartment Name="Properties" />
    </CompartmentShape>
  </Shapes>
  <Connectors>
    <Connector Id="58d2dc35-9060-4f2f-a1ea-971c50eb617a" Description="Description for EPAM.NHModelingLanguage.InheritanceConnector" Name="InheritanceConnector" DisplayName="Inheritance Connector" Namespace="EPAM.NHModelingLanguage" FixedTooltipText="Inheritance Connector" TargetEndStyle="HollowArrow" />
  </Connectors>
  <XmlSerializationBehavior Name="NHModelingLanguageSerializationBehavior" Namespace="EPAM.NHModelingLanguage">
    <ClassData>
      <XmlClassData TypeName="NHModel" MonikerAttributeName="" SerializeId="true" MonikerElementName="nHModelMoniker" ElementName="nHModel" MonikerTypeName="NHModelMoniker">
        <DomainClassMoniker Name="NHModel" />
        <ElementData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="entities">
            <DomainRelationshipMoniker Name="NHModelHasEntities" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Entity" MonikerAttributeName="name" SerializeId="true" MonikerElementName="entityMoniker" ElementName="entity" MonikerTypeName="EntityMoniker">
        <DomainClassMoniker Name="Entity" />
        <ElementData>
          <XmlPropertyData XmlName="name" IsMonikerKey="true">
            <DomainPropertyMoniker Name="Entity/Name" />
          </XmlPropertyData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="properties">
            <DomainRelationshipMoniker Name="EntityHasProperties" />
          </XmlRelationshipData>
          <XmlRelationshipData UseFullForm="true" RoleElementName="parent">
            <DomainRelationshipMoniker Name="EntityInheritedParent" />
          </XmlRelationshipData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="Property" MonikerAttributeName="name" SerializeId="true" MonikerElementName="propertyMoniker" ElementName="property" MonikerTypeName="PropertyMoniker">
        <DomainClassMoniker Name="Property" />
        <ElementData>
          <XmlPropertyData XmlName="name" IsMonikerKey="true">
            <DomainPropertyMoniker Name="Property/Name" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="type">
            <DomainPropertyMoniker Name="Property/Type" />
          </XmlPropertyData>
          <XmlPropertyData XmlName="displayName" Representation="Ignore">
            <DomainPropertyMoniker Name="Property/DisplayName" />
          </XmlPropertyData>
        </ElementData>
      </XmlClassData>
      <XmlClassData TypeName="NHModelHasEntities" MonikerAttributeName="" SerializeId="true" MonikerElementName="nHModelHasEntitiesMoniker" ElementName="nHModelHasEntities" MonikerTypeName="NHModelHasEntitiesMoniker">
        <DomainRelationshipMoniker Name="NHModelHasEntities" />
      </XmlClassData>
      <XmlClassData TypeName="EntityHasProperties" MonikerAttributeName="" SerializeId="true" MonikerElementName="entityHasPropertiesMoniker" ElementName="entityHasProperties" MonikerTypeName="EntityHasPropertiesMoniker">
        <DomainRelationshipMoniker Name="EntityHasProperties" />
      </XmlClassData>
      <XmlClassData TypeName="NHDiagram" MonikerAttributeName="" SerializeId="true" MonikerElementName="nHDiagramMoniker" ElementName="nHDiagram" MonikerTypeName="NHDiagramMoniker">
        <DiagramMoniker Name="NHDiagram" />
      </XmlClassData>
      <XmlClassData TypeName="EntityShape" MonikerAttributeName="" SerializeId="true" MonikerElementName="entityShapeMoniker" ElementName="entityShape" MonikerTypeName="EntityShapeMoniker">
        <CompartmentShapeMoniker Name="EntityShape" />
      </XmlClassData>
      <XmlClassData TypeName="InheritanceConnector" MonikerAttributeName="" SerializeId="true" MonikerElementName="inheritanceConnectorMoniker" ElementName="inheritanceConnector" MonikerTypeName="InheritanceConnectorMoniker">
        <ConnectorMoniker Name="InheritanceConnector" />
      </XmlClassData>
      <XmlClassData TypeName="EntityInheritedParent" MonikerAttributeName="" SerializeId="true" MonikerElementName="entityInheritedParentMoniker" ElementName="entityInheritedParent" MonikerTypeName="EntityInheritedParentMoniker">
        <DomainRelationshipMoniker Name="EntityInheritedParent" />
      </XmlClassData>
    </ClassData>
  </XmlSerializationBehavior>
  <ExplorerBehavior Name="NHModelingLanguageExplorer" />
  <ConnectionBuilders>
    <ConnectionBuilder Name="EntityInheritedParentBuilder">
      <LinkConnectDirective>
        <DomainRelationshipMoniker Name="EntityInheritedParent" />
        <SourceDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Entity" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </SourceDirectives>
        <TargetDirectives>
          <RolePlayerConnectDirective>
            <AcceptingClass>
              <DomainClassMoniker Name="Entity" />
            </AcceptingClass>
          </RolePlayerConnectDirective>
        </TargetDirectives>
      </LinkConnectDirective>
    </ConnectionBuilder>
  </ConnectionBuilders>
  <Diagram Id="87ee6379-866a-4c65-8078-a8a86f971d85" Description="Description for EPAM.NHModelingLanguage.NHDiagram" Name="NHDiagram" DisplayName="NHDiagram" Namespace="EPAM.NHModelingLanguage">
    <Class>
      <DomainClassMoniker Name="NHModel" />
    </Class>
    <ShapeMaps>
      <CompartmentShapeMap>
        <DomainClassMoniker Name="Entity" />
        <ParentElementPath>
          <DomainPath>NHModelHasEntities.NHModel/!NHModel</DomainPath>
        </ParentElementPath>
        <DecoratorMap>
          <TextDecoratorMoniker Name="EntityShape/NameDecorator" />
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Entity/Name" />
            </PropertyPath>
          </PropertyDisplayed>
        </DecoratorMap>
        <CompartmentShapeMoniker Name="EntityShape" />
        <CompartmentMap>
          <CompartmentMoniker Name="EntityShape/Properties" />
          <ElementsDisplayed>
            <DomainPath>EntityHasProperties.Properties/!Property</DomainPath>
          </ElementsDisplayed>
          <PropertyDisplayed>
            <PropertyPath>
              <DomainPropertyMoniker Name="Property/DisplayName" />
            </PropertyPath>
          </PropertyDisplayed>
        </CompartmentMap>
      </CompartmentShapeMap>
    </ShapeMaps>
    <ConnectorMaps>
      <ConnectorMap>
        <ConnectorMoniker Name="InheritanceConnector" />
        <DomainRelationshipMoniker Name="EntityInheritedParent" />
      </ConnectorMap>
    </ConnectorMaps>
  </Diagram>
  <Designer CopyPasteGeneration="CopyPasteOnly" FileExtension="nhml" EditorGuid="7fd70b7a-c21a-4968-b82b-2370acfbe125">
    <RootClass>
      <DomainClassMoniker Name="NHModel" />
    </RootClass>
    <XmlSerializationDefinition CustomPostLoad="false">
      <XmlSerializationBehaviorMoniker Name="NHModelingLanguageSerializationBehavior" />
    </XmlSerializationDefinition>
    <ToolboxTab TabText="NHModelingLanguage">
      <ElementTool Name="EntityTool" ToolboxIcon="Resources\ExampleShapeToolBitmap.bmp" Caption="Entity" Tooltip="Entity Tool" HelpKeyword="EntityTool">
        <DomainClassMoniker Name="Entity" />
      </ElementTool>
      <ConnectionTool Name="InheritanceTool" ToolboxIcon="Resources\ExampleConnectorToolBitmap.bmp" Caption="Inheritance" Tooltip="Inheritance Tool" HelpKeyword="InheritanceTool">
        <ConnectionBuilderMoniker Name="NHModelingLanguage/EntityInheritedParentBuilder" />
      </ConnectionTool>
    </ToolboxTab>
    <Validation UsesMenu="true" UsesOpen="false" UsesSave="true" UsesLoad="false" />
    <DiagramMoniker Name="NHDiagram" />
  </Designer>
  <Explorer ExplorerGuid="00097221-569f-4c10-8c69-76866dc4a379" Title="NHModelingLanguage Explorer">
    <ExplorerBehaviorMoniker Name="NHModelingLanguage/NHModelingLanguageExplorer" />
  </Explorer>
</Dsl>