---
category: dataservice
subCategory: configuration
title: Data Service
subTitle: Configuration
isSubPage: true
permalink: /dataservice/configuration/
sections:
  general: General Information
  endpoint: REST API Endpoints
  sdk: .NET SDK Methods
---

## {{ page.sections['general'] }}

The PiWeb configuration consists of a list of attributes for all types of entities. 
The different types of entites are: 

* *parts*, 
* *characteristics*, 
* *measurements*, 
* *values* and 
* *catalogues*.

The attributes are either ```AttributeDefinition``` or ```CatalogueAttributeDefinition``` objects. Both are derived from the abstract base type ```AbstractAttributeDefinition```. 

###AbstractAttributeDefinition

Property      | Type         | Description
--------------|--------------|--------------------------------------------------------------
key           | ```ushort``` | The attribute's key, by which the attribute can be uniquely identified
description   | ```string``` | The attribute's name or a short description 

###AttributeDefinition : AbstractAttributeDefinition

Property      | Type                | Description
--------------|---------------------|--------------------------------------------------------------
type          | ```AttributeType``` | The attribute's type. *AlphaNumeric*, *Integer*, *Float* or *DateTime*
length        | ```ushort```        | The attribute's maximum length. Only set if the type is *AlphaNumeric*
definitionType| ```string```        | Always has the value 'AttributeDefinition' and is used to differentiate between  ```AttributeDefinition``` and ```CatalogueAttributeDefinition``` (only relevant and available for the REST API)

###CatalogueAttributeDefinition : AbstractAttributeDefinition

Property      | Type         | Description
--------------|--------------|------------------------------------------------------------
catalogue     | ```Guid```   | The uuid of the catalogue that contains the attribute's values
definitionType| ```string``` | Always has the value 'CatalogueAttributeDefinition' and is used to differentiate between  ```AttributeDefinition``` and ```CatalogueAttributeDefinition``` (only relevant and available for the REST API)

{% comment %}----------------------------------------------------------------------------------------------- {% endcomment %}

## {{ page.sections['endpoint'] }}

The configuration can be fetched, created, updated and deleted using the following endpoints. These endpoints do not provide filter parameters.

URL Endpoint | GET | PUT | POST | DELETE
-------------|-----|-----|------|-------
/configuration| Returns the attribute configuration (list of attributes for each entity). | *Not supported* | *Not supported* | Deletes all attribute definitions.
/configuration/*entityType*| *Not supported* | Updates the attribute definitions transfered within the body of the request for the given *entityType* |  Creates the attribute definitions transfered within the body of the request for the given *entityType* | *Not supported*
configuration/*entityType*/{*Comma seperated list of attribute definition ids*} | *Not supported* | *Not supported* | *Not supported* | Deletes the attribute definitions identified by the *List of attribute definition ids* for the given *entityType*. If the *List of attribute definition ids* is empty, all attributes for the given *entityType* are deleted.

### Get Configuration

Fetching the entire configuration returns the attribute definitions for all entity types.

{% assign exampleCaption="Fetching the configuration including all attriutes" %}

{% capture jsonrequest %}
{% highlight http %}
GET /dataServiceRest/configuration HTTP/1.1
{% endhighlight %}
{% endcapture %}

{% capture jsonresponse %}
{% highlight json %}
{
   ...
   "data":
   [
       {
          "partAttributes":
          [
           [
               "key":1001,
               "description":"partNumber",
               "length":30,
               "type":"AlphaNumeric",
               "definitionType":"AttributeDefinition"
           ],
           ...
          ],
          "characteristicAttributes":
          [
           [
               "key":2001,
               "description":"characteristicNumber",
               "length":20,
               "type":"AlphaNumeric",
               "definitionType":"AttributeDefinition"
           ],
           ...
          ],
          "measurementAttributes":
          [
                "key": 8,
                "description": "inspector",
                "catalogue": "8c376bee-ffe3-4ee4-abb9-a55b492e69ad",
                "definitionType": "CatalogueAttributeDefinition"
          ...
          ],
          "valueAttributes":
          [
          ...
          ],
          "catalogueAttributes":
          [
          ...
          ]
       }
   ]
}
{% endhighlight %}
{% endcapture %}

{% include exampleFieldset.html %}

### Add Attributes

Each add request must contain the attribute definitions and the entity type which these definitions belong to. The entity type ist part of the uri and the attributes are transmitted in the body of the request.

{% assign exampleCaption="Adding a part attribute with the key 1001 to the configuration" %}

{% capture jsonrequest %}
{% highlight http %}
POST /dataServiceRest/configuration/parts HTTP/1.1
{% endhighlight %}

{% highlight json %}
[
  {
    "key":1001,
    "description":"partNumber",
    "length":30,
    "type":"AlphaNumeric",
    "definitionType":"AttributeDefinition"
  }
]
{% endhighlight %}
{% endcapture %}

{% capture jsonresponse %}
{% highlight http %}
HTTP/1.1 201 Created
{% endhighlight %}

{% highlight json %}
{
   "status":
   {
       "statusCode": 201,
       "statusDescription": "Created"
   },
   "category": "Success"
}
{% endhighlight %}
{% endcapture %}

{% include exampleFieldset.html %}

### Update Attributes

Each update request must contain the attribute definitions and the entity type which these definitions belong to. The entity type ist part of the uri and the attributes are transmitted in the body of the request.

{% assign exampleCaption="Updating the part attribute with key 1001 - change length from 30 to 50" %}

{% capture jsonrequest %}
{% highlight http %}
PUT /dataServiceRest/configuration/parts HTTP/1.1
{% endhighlight %}

{% highlight json %}
[
  {
    "key":1001,
    "description":"partNumber",
    "length":50,
    "type":"AlphaNumeric",
    "definitionType":"AttributeDefinition"
  }
]
{% endhighlight %}
{% endcapture %}

{% capture jsonresponse %}
{% highlight http %}
HTTP/1.1 200 Ok
{% endhighlight %}

{% highlight json %}
{
   "status":
   {
       "statusCode": 200,
       "statusDescription": "Ok"
   },
   "category": "Success"
}
{% endhighlight %}
{% endcapture %}

{% include exampleFieldset.html %}

### Delete Attributes

There are three different options for deleting attributes: 

* Delete all attributes in the configuration, 
* Delete all attributes of a certain entity or 
* Delete specific attributes of a specific entity
 
The following examples demonstrate these options.

{% assign exampleCaption="Delete all attributes of the current configuration" %}

{% capture jsonrequest %}
{% highlight http %}
DELETE /dataServiceRest/configuration HTTP/1.1
{% endhighlight %}
{% endcapture %}

{% capture jsonresponse %}
{% highlight http %}
HTTP/1.1 200 Ok
{% endhighlight %}

{% highlight json %}
{
   "status":
   {
       "statusCode": 200,
       "statusDescription": "Ok"
   },
   "category": "Success"
}
{% endhighlight %}
{% endcapture %}

{% include exampleFieldset.html %}

{% assign exampleCaption="Delete all part attributes" %}

{% capture jsonrequest %}
{% highlight http %}
DELETE /dataServiceRest/configuration/part HTTP/1.1
{% endhighlight %}
{% endcapture %}

{% capture jsonresponse %}
{% highlight http %}
HTTP/1.1 200 Ok
{% endhighlight %}

{% highlight json %}
{
   "status":
   {
       "statusCode": 200,
       "statusDescription": "Ok"
   },
   "category": "Success"
}
{% endhighlight %}
{% endcapture %}

{% include exampleFieldset.html %}

{% assign exampleCaption="Delete the part attribute with the key 1001" %}

{% capture jsonrequest %}
{% highlight http %}
DELETE /dataServiceRest/configuration/part/{1001} HTTP/1.1
{% endhighlight %}
{% endcapture %}

{% capture jsonresponse %}
{% highlight http %}
HTTP/1.1 200 Ok
{% endhighlight %}

{% highlight json %}
{
   "status":
   {
       "statusCode": 200,
       "statusDescription": "Ok"
   },
   "category": "Success"
}
{% endhighlight %}
{% endcapture %}

{% include exampleFieldset.html %}

{% comment %}----------------------------------------------------------------------------------------------- {% endcomment %}

## {{ page.sections['sdk'] }}

### Get Configuration

{% assign caption="GetConfiguration" %}
{% assign icon=site.images['function-get'] %}
{% assign description="Fetches the entire configuration for all entity types." %}
{% capture parameterTable %}
Name           | Type                    | Description
---------------|-------------------------|--------------------------------------------------
token          | ```CancellationToken``` | Parameter is optional and allows to cancel the asyncronous call.
{% endcapture %}

{% assign exampleCaption="Get the configuration" %}
{% capture example %}
{% highlight csharp %}
var client = new DataServiceRestClient( new Uri( "http://piwebserver:8080" ) );
Configuration config = await client.GetConfiguration();
{% endhighlight %}
{% endcapture %}

{% include sdkFunctionFieldset.html %}

### Create Configuration Attributes

{% assign caption="CreateAttributeDefinition" %}
{% assign icon=site.images['function-create'] %}
{% assign description="Adds a single attribute for a given entity to the configuration." %}
{% capture parameterTable %}
Name           | Type                    | Description
---------------|-------------------------|--------------------------------------------------
entity         | ```Entity```            | Specifies the entity which the attribute belongs to. Possible values are ```Part```, ```Characteristic```, ```Measurement```, ```Value``` or ```Catalogue```.
definition     | ```AbstractAttributeDefinition``` | Depending on the entity, the ```AbstractAttributeDefinition``` definition contains an ```AttributeDefinition``` or a ```CatalogueAttributeDefinition``` object, which then contains the attribute's values.
token          | ```CancellationToken``` | Parameter is optional and allows to cancel the asyncronous call.
{% endcapture %}

{% assign exampleCaption="Adding a part attribute with the key 1001 to the configuration" %}
{% capture example %}
{% highlight csharp %}
var client = new DataServiceRestClient( new Uri( "http://piwebserver:8080" ) );
var attributeDefinition = 
      new AttributeDefinition( 1001, "partNumber", AttributeType.AlphaNumeric, 30 );
await client.CreateAttributeDefinition( Entity.Part, attributeDefinition );
{% endhighlight %}
{% endcapture %}

{% include sdkFunctionFieldset.html %}

{% assign caption="CreateAttributeDefinitions" %}
{% assign icon=site.images['function-create'] %}
{% assign description="Adds multiple attributes for a given entity to the configuration." %}
{% capture parameterTable %}
 Name          | Type                    | Description
---------------|-------------------------|--------------------------------------------------
entity         | ```Entity```            | Specifies the entity which the attributes belong to. Possible values are ```Part```, ```Characteristic```, ```Measurement```, ```Value``` or ```Catalogue```.
definitions     | ```AbstractAttributeDefinition[]``` | Depending on the entity, the ```AbstractAttributeDefinition``` definition contains ```AttributeDefinition``` or a ```CatalogueAttributeDefinition``` object, which then contains the attribute's values.
token          | ```CancellationToken```       | Parameter is optional and allows to cancel the asyncronous call.
{% endcapture %}

{% assign exampleCaption = "" %}

{% include sdkFunctionFieldset.html %}

### Update Configuration Attributes

{% assign caption="UpdateAttributeDefinitions" %}
{% assign icon=site.images['function-update'] %}
{% assign description="Updates one or more attributes for a given entity." %}
{% capture parameterTable %}
 Name          | Type                    | Description
---------------|-------------------------|--------------------------------------------------
entity         | ```Entity```            | Specifies the entity which the attributes belong to. Possible values are ```Part```, ```Characteristic```, ```Measurement```, ```Value``` or ```Catalogue```.
definitions     | ```AbstractAttributeDefinition[]``` | Depending on the entity, the ```AbstractAttributeDefinition``` definition contains ```AttributeDefinition``` or a ```CatalogueAttributeDefinition``` object, which then contains the attribute's values.
token          | ```CancellationToken``` | Parameter is optional and allows to cancel the asyncronous call.
{% endcapture %}

{% assign exampleCaption="Updating the part attribute with key 1001 - change length from 30 to 50" %}
{% capture example %}
{% highlight csharp %}
var client = new DataServiceRestClient( new Uri( "http://piwebserver:8080" ) );

//Get the attribute
var config = await GetConfiguration();
var partAttribute = config.PartAttributes.Where( p => p.Key == 1001);

//Change the length
partAttribute.Length = 50;
client.UpdateAttributeDefinition( Entity.Part, attributeDefinition );
{% endhighlight %}
{% endcapture %}

{% include sdkFunctionFieldset.html %}


### Delete Configuration Attributes

{% assign caption="DeleteAttributeDefinitions" %}
{% assign icon=site.images['function-delete'] %}
{% assign description="Deletes all or specific attributes of a given entity from the configuration." %}
{% capture parameterTable %}
 Name          | Type                    | Description
---------------|-------------------------|--------------------------------------------------
entity         | ```Entity```            | Specifies the entity which the attributes belong to. Possible values are ```Part```, ```Characteristic```, ```Measurement```, ```Value``` or ```Catalogue```.
keys           | ```ushort[]```          | Contains the keys of the attributes which should be deleted. If it is empty, all attributes of the given *entity* are deleted.
token          | ```CancellationToken``` | Parameter is optional and allows to cancel the asyncronous call.
{% endcapture %}

{% assign exampleCaption="Delete the part attribute with the key 1001 from the configuration" %}
{% capture example %}
{% highlight csharp %}
var client = new DataServiceRestClient( new Uri( "http://piwebserver:8080" ) );
await client.DeleteAttributeDefinitions( Entity.Part, new ushort[]{ (ushort)1001 } );
{% endhighlight %}
{% endcapture %}

{% include sdkFunctionFieldset.html %}


{% assign caption="DeleteAllAttributeDefinitions" %}
{% assign icon=site.images['function-delete'] %}
{% assign description="Deletes all attributes of all entities from the configuration." %}
{% capture parameterTable %}
Name           | Type                    | Description
---------------|-------------------------|--------------------------------------------------
token          | ```CancellationToken``` | Parameter is optional and allows to cancel the asyncronous call.
{% endcapture %}

{% assign exampleCaption="Delete all attributes from the configuration" %}
{% capture example %}
{% highlight csharp %}
var client = new DataServiceRestClient( "http://piwebserver:8080" );
client.DeleteAllAttributeDefinitions();
{% endhighlight %}
{% endcapture %}

{% include sdkFunctionFieldset.html %}