﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace ETrade.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission"}},
            new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"}},
            new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"} },
            new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"}},
            new ApiResource("ResourceBasket"){Scopes={"BasketFullPermission"}},
            new ApiResource("ResourceComment"){Scopes={"CommentFullPermission"}},
            new ApiResource("ResourcePayment"){Scopes={"PaymentFullPermission"}},
            new ApiResource("ResourceImage"){Scopes={"ImageFullPermission"}},
            new ApiResource("ResourceMessage"){Scopes={"MessageFullPermission"}},
            new ApiResource("ResourceOcelot"){Scopes={"OcelottFullPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
           new IdentityResources.OpenId(),
           new IdentityResources.Profile(),
           new IdentityResources.Email(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission" ,"Read authority for catalog operation"),
            new ApiScope("DiscountFullPermission","Full authority for discount operations"),
            new ApiScope("OrderFullPermission","Full authority for order operations"),
            new ApiScope("CargoFullPermission","Full authority for cargo operations"),
            new ApiScope("BasketFullPermission","Full authority for basket operations"),
            new ApiScope("CommentFullPermission","Full authority for comment operations"),
            new ApiScope("PaymentFullPermission","Full authority for payment operations"),
            new ApiScope("ImageFullPermission","Full authority for image operations"),
            new ApiScope("MessageFullPermission","Full authority for message operations"),
            new ApiScope("OcelottFullPermission","Full authority for ocelot operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };
        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor
            new Client
            {
                ClientId="ETradeVisitorId",
                ClientName="ETrade Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("etradesecret".Sha256())},
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermission", "OcelottFullPermission", "CommentFullPermission" , "ImageFullPermission",
                "CommentFullPermission"}

            },
            //Manager
            new Client
            {
                ClientId="ETradeManagerId",
                ClientName="ETrade Manager User",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("etradesecret".Sha256()) },
                AllowedScopes={ "CatalogReadPermission" , "CatalogFullPermission", "BasketFullPermission", "OcelottFullPermission" , "PaymentFullPermission"
                ,"ImageFullPermission","CommentFullPermission","DiscountFullPermission","OrderFullPermission","MessageFullPermission","CargoFullPermission",
                      IdentityServerConstants.LocalApi.ScopeName,
                 IdentityServerConstants.StandardScopes.Email,
                 IdentityServerConstants.StandardScopes.OpenId,
                 IdentityServerConstants.StandardScopes.Profile,}

            },
            //Admin
            new Client
            {
                ClientId="ETradeAdminId",
                ClientName="ETrade Admin User",
                 AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={new Secret("etradesecret".Sha256()) },
                AllowedScopes={ "CatalogFullPermission", "CatalogReadPermission" , "DiscountFullPermission" , "OrderFullPermission" ,
                    "CargoFullPermission","BasketFullPermission","OcelottFullPermission","CommentFullPermission", "PaymentFullPermission",
                    "ImageFullPermission",
                 IdentityServerConstants.LocalApi.ScopeName,
                 IdentityServerConstants.StandardScopes.Email,
                 IdentityServerConstants.StandardScopes.OpenId,
                 IdentityServerConstants.StandardScopes.Profile,
                },
                AccessTokenLifetime=600

            }

        };
    }
}