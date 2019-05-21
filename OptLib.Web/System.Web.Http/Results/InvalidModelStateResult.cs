// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace System.Web.Http.Results
{
    /// <summary>
    /// Represents an action result that returns a <see cref="HttpStatusCode.BadRequest"/> response and performs
    /// content negotiation on an <see cref="HttpErrorNegareh"/> based on a <see cref="ModelStateDictionary"/>.
    /// </summary>
    public class InvalidModelStateResultNegareh : IHttpActionResult
    {
        private readonly string[] _modelNames;
        private readonly ModelStateDictionary _modelState;
        private readonly ExceptionResultNegareh.IDependencyProvider _dependencies;

        /// <summary>Initializes a new instance of the <see cref="InvalidModelStateResultNegareh"/> class.</summary>
        /// <param name="modelState">The model state to include in the error.</param>
        /// <param name="includeErrorDetail">
        /// <see langword="true"/> if the error should include exception messages; otherwise, <see langword="false"/>.
        /// </param>
        /// <param name="contentNegotiator">The content negotiator to handle content negotiation.</param>
        /// <param name="request">The request message which led to this result.</param>
        /// <param name="formatters">The formatters to use to negotiate and format the content.</param>
        public InvalidModelStateResultNegareh(ModelStateDictionary modelState, bool includeErrorDetail,
            IContentNegotiator contentNegotiator, HttpRequestMessage request,
            IEnumerable<MediaTypeFormatter> formatters)
            : this(modelState, new ExceptionResultNegareh.DirectDependencyProvider(includeErrorDetail, contentNegotiator,
                request, formatters))
        {
        }
        public InvalidModelStateResultNegareh(ModelStateDictionary modelState, bool includeErrorDetail,
            IContentNegotiator contentNegotiator, HttpRequestMessage request,
            IEnumerable<MediaTypeFormatter> formatters, params string[] modelNames)
            : this(modelState, new ExceptionResultNegareh.DirectDependencyProvider(includeErrorDetail, contentNegotiator,
                request, formatters), modelNames)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="InvalidModelStateResultNegareh"/> class.</summary>
        /// <param name="modelState">The model state to include in the error.</param>
        /// <param name="controller">The controller from which to obtain the dependencies needed for execution.</param>
        public InvalidModelStateResultNegareh(ModelStateDictionary modelState, ApiController controller)
            : this(modelState, new ExceptionResultNegareh.ApiControllerDependencyProvider(controller))
        {
        }
        public InvalidModelStateResultNegareh(ModelStateDictionary modelState, ApiController controller, params string[] modelNames)
            : this(modelState, new ExceptionResultNegareh.ApiControllerDependencyProvider(controller), modelNames)
        {
        }

        private InvalidModelStateResultNegareh(ModelStateDictionary modelState,
            ExceptionResultNegareh.IDependencyProvider dependencies)
        {
            if (modelState == null)
            {
                throw new ArgumentNullException("modelState");
            }

            Contract.Assert(dependencies != null);

            _modelState = modelState;
            _dependencies = dependencies;
            _modelNames = null;
        }
        private InvalidModelStateResultNegareh(ModelStateDictionary modelState,
            ExceptionResultNegareh.IDependencyProvider dependencies, params string[] modelNames)
        {
            if (modelState == null)
            {
                throw new ArgumentNullException("modelState");
            }

            Contract.Assert(dependencies != null);

            _modelState = modelState;
            _dependencies = dependencies;
            _modelNames = modelNames;
        }

        /// <summary>Gets the model state to include in the error.</summary>
        public ModelStateDictionary ModelState
        {
            get { return _modelState; }
        }

        /// <summary>Gets a value indicating whether the error should include exception messages.</summary>
        public bool IncludeErrorDetail
        {
            get { return _dependencies.IncludeErrorDetail; }
        }

        /// <summary>Gets the content negotiator to handle content negotiation.</summary>
        public IContentNegotiator ContentNegotiator
        {
            get { return _dependencies.ContentNegotiator; }
        }

        /// <summary>Gets the request message which led to this result.</summary>
        public HttpRequestMessage Request
        {
            get { return _dependencies.Request; }
        }

        /// <summary>Gets the formatters to use to negotiate and format the content.</summary>
        public IEnumerable<MediaTypeFormatter> Formatters
        {
            get { return _dependencies.Formatters; }
        }

        /// <inheritdoc />
        public virtual Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        private HttpResponseMessage Execute()
        {
            HttpErrorNegareh error;
            if (_modelNames == null)
                error = new HttpErrorNegareh(_modelState, _dependencies.IncludeErrorDetail);
            else
                error = new HttpErrorNegareh(_modelState, _dependencies.IncludeErrorDetail, _modelNames);
            return NegotiatedContentResultNegareh<HttpErrorNegareh>.Execute(HttpStatusCode.BadRequest, error,
                _dependencies.ContentNegotiator, _dependencies.Request, _dependencies.Formatters);
        }
    }
}
