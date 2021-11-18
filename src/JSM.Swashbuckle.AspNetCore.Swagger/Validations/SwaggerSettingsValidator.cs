using FluentValidation;
using JSM.Swashbuckle.AspNetCore.Swagger.Settings;
using Microsoft.OpenApi.Models;

namespace JSM.Swashbuckle.AspNetCore.Swagger.Validations
{
    public class SwaggerSettingsValidator : AbstractValidator<SwaggerSettings>
    {
        public SwaggerSettingsValidator()
        {
            RuleFor(m => m).NotNull().NotEmpty()
                .WithMessage("O campo Swagger no arquivo de configuração não pode ser vazio.");

            RuleFor(m => m.BasePath).NotNull().NotEmpty()
                .WithMessage("O campo BasePath no arquivo de configuração não pode ser vazio.");

            RuleFor(m => m.FirstVersionIdentifier)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo FirstVersionIdentifier no arquivo de configuração não pode ser vazio.");

            RuleFor(m => m.RouteTemplate)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo RouteTemplate no arquivo de configuração não pode ser vazio.");

            #region Security
            RuleFor(m => m.Security)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo Swagger > Security no arquivo de configuração não pode ser vazio.");

            When(m => m.Security != null, () =>
            {
                RuleFor(m => m.Security.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo Security > Name no arquivo de configuração não pode ser vazio.");

                RuleFor(m => m.Security.Scheme)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo Security > Scheme no arquivo de configuração não pode ser vazio.");

                When(m => m.Security.Scheme != null, () =>
                {
                    RuleFor(m => m.Security.Scheme.Description)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("O campo Security > Scheme > Description no arquivo de configuração não pode ser vazio.");

                    RuleFor(m => m.Security.Scheme.Name)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("O campo Security > Scheme > Name no arquivo de configuração não pode ser vazio.");

                    RuleFor(m => m.Security.Scheme.In)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("O campo Security > Scheme > Ine no arquivo de configuração não pode ser vazio.");

                    RuleFor(m => m.Security.Scheme)
                        .Must(p => p.Type == SecuritySchemeType.ApiKey)
                        .WithMessage("SecuritySchemeType do campo Security > Scheme > Type no arquivo de configuração é inválido.");
                });
            });
            #endregion

            #region InternalDoc
            RuleFor(m => m.InternalDoc)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo Swagger > InternalDoc Name no arquivo de configuração não pode ser vazio.");

            When(m => m.InternalDoc != null, () =>
            {
                RuleFor(m => m.InternalDoc.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo InternalDoc > Name no arquivo de configuração não pode ser vazio.");

                RuleFor(m => m.InternalDoc.Info)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo InternalDoc > Info  no arquivo de configuração não pode ser vazio.");

                When(m => m.InternalDoc.Info != null, () =>
                {
                    RuleFor(m => m.InternalDoc.Info.Title)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("O campo InternalDoc > Info > Title no arquivo de configuração não pode ser vazio.");

                    RuleFor(m => m.InternalDoc.Info.Description)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("O campo InternalDoc > Info > Description no arquivo de configuração não pode ser vazio.");
                });

                RuleFor(m => m.InternalDoc.RedocOptions)
               .NotNull()
               .NotEmpty()
               .WithMessage("O campo InternalDoc > RedocOptions no arquivo de configuração não pode ser vazio.");

                When(m => m.InternalDoc.RedocOptions != null, () =>
                {
                    RuleFor(m => m.InternalDoc.RedocOptions.SpecUrl)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("O campo InternalDoc > RedocOptions > SpecUrl no arquivo de configuração não pode ser vazio.");

                    RuleFor(m => m.InternalDoc.RedocOptions.RoutePrefix)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("O campo InternalDoc > RedocOptions > RoutePrefix no arquivo de configuração não pode ser vazio.");

                    RuleFor(m => m.InternalDoc.RedocOptions.DocumentTitle)
                       .NotNull()
                       .NotEmpty()
                       .WithMessage("O campo InternalDoc > RedocOptions > DocumentTitle no arquivo de configuração não pode ser vazio.");
                });
            });
            #endregion

            #region ExternalDoc
            RuleFor(m => m.ExternalDoc)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo Swagger > ExternalDoc no arquivo de configuração não pode ser vazio.");

            When(m => m.ExternalDoc != null, () =>
            {
                RuleFor(m => m.ExternalDoc.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo ExternalDoc > Name no arquivo de configuração não pode ser vazio.");

                RuleFor(m => m.ExternalDoc.Info)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo ExternalDoc > Info no arquivo de configuração não pode ser vazio.");

                When(m => m.ExternalDoc.Info != null, () =>
                {
                    RuleFor(m => m.ExternalDoc.Info.Title)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("O campo ExternalDoc > Info > Title no arquivo de configuração não pode ser vazio.");

                    RuleFor(m => m.ExternalDoc.Info.Description)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("O campo ExternalDoc > Info > Description no arquivo de configuração não pode ser vazio.");
                });

                RuleFor(m => m.ExternalDoc.RedocOptions)
               .NotNull()
               .NotEmpty()
               .WithMessage("O campo ExternalDoc > RedocOptions no arquivo de configuração não pode ser vazio.");

                When(m => m.ExternalDoc.RedocOptions != null, () =>
                {
                    RuleFor(m => m.InternalDoc.RedocOptions.SpecUrl)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("O campo ExternalDoc > RedocOptions > SpecUrl no arquivo de configuração não pode ser vazio.");

                    RuleFor(m => m.ExternalDoc.RedocOptions.RoutePrefix)
                        .NotNull()
                        .NotEmpty()
                        .WithMessage("O campo ExternalDoc > RedocOptions > RoutePrefix no arquivo de configuração não pode ser vazio.");

                    RuleFor(m => m.ExternalDoc.RedocOptions.DocumentTitle)
                       .NotNull()
                       .NotEmpty()
                       .WithMessage("O campo ExternalDoc > RedocOptions > DocumentTitle no arquivo de configuração não pode ser vazio.");
                });
            });
            #endregion

            #region FilePaths
            RuleFor(m => m.FilePaths)
                .NotNull()
                .NotEmpty()
                .WithMessage("O campo Swagger > FilePaths no arquivo de configuração não pode ser vazio.");

            When(m => m.FilePaths != null, () =>
            {
                RuleFor(m => m.FilePaths.Api)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("O campo FilePaths > Api no arquivo de configuração não pode ser vazio.");

                RuleFor(m => m.FilePaths.Domain)
                    .NotNull()
                    .NotEmpty()
                    .WithMessage("O campo FilePaths > Domain no arquivo de configuração não pode ser vazio.");

            });
            #endregion

        }
    }
}
