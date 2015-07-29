using Nancy;
using Nancy.ModelBinding;
using Nancy.Security;
using Superplayer.Ads.Model.Repository;
using Superplayer.Api.Model.Repository;
using Superplayer.Model.Repositories;
using System;

namespace Superplayer.Beet.PlayAgent
{
    public class Module : NancyModule
    {
        public Module()
        {
            var savePlayService = new SavePlayService();

            Post["/"] = _ =>
            {
                this.RequiresAuthentication();

                var data = this.Bind<SavePlayData>();

                var result = savePlayService.Run(data);

                return Negotiate
                    .WithStatusCode(HttpStatusCode.Created)
                    .WithModel(result);
            };
        }
    }
}
