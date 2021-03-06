using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace Dos.User.Api.Insfrastructure.AspNet
{
    public class ProblemDetailsBuilder : IProblemDetailsBuilder
    {
        private readonly HttpContext _httpContext;

        private string? _title;
        private string? _type;
        private string? _detail;
        private string? _instance;
        private List<string> _errors;

        public ProblemDetailsBuilder(HttpContext httpContext)
        {
            this._httpContext = httpContext;
            this._errors = new List<string>();
        }


        public ProblemDetailsBuilder WithTitle(string title)
        {
            this._title = title;

            return this;
        }

        public ProblemDetailsBuilder WithType(string type)
        {
            this._type = type;

            return this;
        }

        public ProblemDetailsBuilder WithDetail(string detail)
        {
            this._detail = detail;

            return this;
        }

        public ProblemDetailsBuilder WithInstance(string instance)
        {
            this._instance = instance;

            return this;
        }

        public ProblemDetailsBuilder WithErrors(IEnumerable<string> errors)
        {
            this._errors = new List<string>(errors);

            return this;
        }

        protected void ApplyDefaults(ProblemDetails problemDetails)
        {
            var traceId = Activity.Current?.Id ?? this._httpContext?.TraceIdentifier;
            if (traceId != null)
            {
                problemDetails.Extensions["traceId"] = traceId;
            }

           
        }
        public ProblemDetails Build()
        {
            var problemDetails = new ProblemDetails
            {
                Title = this._title,
                Type = this._type,
                Detail = this._detail,
                Instance = this._instance
            };
            this.ApplyDefaults(problemDetails);

            return problemDetails;
        }
    }
}
