// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Authentication.OAuth
{
    /// <summary>
    /// Default implementation.
    /// </summary>
    public class OAuthEvents : RemoteAuthenticationEvents
    {
        /// <summary>
        /// Gets or sets the function that is invoked when the CreatingTicket method is invoked.
        /// </summary>
        public Func<OAuthCreatingTicketContext, Task> OnCreatingTicket { get; set; } = context => Task.CompletedTask;

        /// <summary>
        /// Gets or sets the delegate that is invoked when the RedirectToAuthorizationEndpoint method is invoked.
        /// </summary>
        public Func<RedirectContext<OAuthOptions>, Task> OnRedirectToAuthorizationEndpoint { get; set; } = context =>
        {
            context.Response.Redirect(context.RedirectUri);
            return Task.CompletedTask;
        };

        /// <summary>
        /// Gets or sets the delegate that is invoked when the ExchangeCode method is invoked.
        /// </summary>
        public Func<OAuthExchangeCodeContext, Task> OnExchangeCode { get; set; } = context => Task.CompletedTask;

        /// <summary>
        /// Invoked after the provider successfully authenticates a user.
        /// </summary>
        /// <param name="context">Contains information about the login session as well as the user <see cref="System.Security.Claims.ClaimsIdentity"/>.</param>
        /// <returns>A <see cref="Task"/> representing the completed operation.</returns>
        public virtual Task CreatingTicket(OAuthCreatingTicketContext context) => OnCreatingTicket(context);

        /// <summary>
        /// Called when a Challenge causes a redirect to authorize endpoint in the OAuth handler.
        /// </summary>
        /// <param name="context">Contains redirect URI and <see cref="AuthenticationProperties"/> of the challenge.</param>
        public virtual Task RedirectToAuthorizationEndpoint(RedirectContext<OAuthOptions> context) => OnRedirectToAuthorizationEndpoint(context);

        /// <summary>
        /// Invoked before the request to exchange the code for the access token.
        /// </summary>
        /// <param name="context">Contains the code returned, the redirect URI and the <see cref="AuthenticationProperties"/>.</param>
        /// <returns></returns>
        public virtual Task ExchangeCode(OAuthExchangeCodeContext context) => OnExchangeCode(context);
    
    }
}
