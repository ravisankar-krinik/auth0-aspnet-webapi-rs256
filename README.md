# Auth0 + ASP.NET WebAPI OWIN RS256 Example

This is the seed project you need to use if you're going to create an ASP.NET WebAPI application using OWIN with RS256 (asymmetric signature).

## Configuring Auth0

In order for Auth0 to sign the token with the private key instead of the client secret, we need to configure the application to use RS256. To do so, go to the [Auth0 Dashboard](https://manage.auth0.com) and open your application. Click on "Show Advanced Settings" and under the OAuth tab set the "JsonWebToken Token Signature Algorithm" to RS256.

## Implementation

In this example we're using the `Microsoft.Owin.Security.ActiveDirectory` NuGet package. This NuGet package is intended to be used with ADFS, but we can reuse it with Auth0. It will basically get the signing certificate from Auth0 using the WS-Federation endpoint, and validate incoming tokens using this certificate.

## Running the example

This sample was tested with Visual Studio 2015.

You also need to set the ClientId and Domain of your Auth0 app in the web.config file. To do that just look for the following keys and enter the right content:

```CSharp
<add key="Auth0Domain" value="https://{DOMAIN}/" />
<add key="Auth0ClientID" value="{CLIENT_ID}"/>
```

After that just press **F5** to run the application. It will start running in port **3001**. If you browse to [http://localhost:3001/ping](http://localhost:3001/ping) you should receive a response message.

To access the secure endpoint at [http://localhost:3001/secured/ping](http://localhost:3001/secured/ping) you need to pass an Authorization header and pass the token you obtained when the user signed in as a Beared token, e.g.

``` bash
Authorization: Bearer <token>
```