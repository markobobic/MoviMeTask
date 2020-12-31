using Autofac;
using Autofac.Integration.Mvc;
using MovieMe.Models;
using MovieMe.Repository;
using MovieMe.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MovieMe.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder
            .RegisterType<ApplicationDbContext>()
            .AsSelf().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericRepository<>))
               .As(typeof(IGenericRepository<>)).InstancePerRequest();
            builder.RegisterGeneric(typeof(EntityService<>))
               .As(typeof(IEntityService<>)).InstancePerRequest();
            builder.RegisterGeneric(typeof(ArtistRepository<>))
              .As(typeof(IArtistRepository<>)).InstancePerRequest();
            builder.RegisterType(typeof(GenreRepository))
              .As(typeof(IGenreRepository)).InstancePerRequest();
            builder.RegisterType(typeof(FilmRepository))
             .As(typeof(IFilmRepository)).InstancePerRequest();
            builder.RegisterType(typeof(BillRepository))
             .As(typeof(IBillRepository)).InstancePerRequest();
            builder.RegisterType(typeof(FilmService))
            .As(typeof(IFilmService)).InstancePerRequest();
            builder.RegisterType(typeof(GenreService))
            .As(typeof(IGenreService)).InstancePerRequest();
            builder.RegisterType(typeof(BillService))
           .As(typeof(IBillService)).InstancePerRequest();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}