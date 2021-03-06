﻿namespace Configuration.Dependencies
{
    using Autofac;
	using Autofac.Core;
	using Autofac.Extensions.DependencyInjection;
	using AutoMapper;
    using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Http;
	using Microsoft.Extensions.DependencyInjection;
	using System;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Core.Services.JWT;

    internal class DependencyConfigurator
	{
		public void Registertypes<TContext, TUser, TRole, TKey>(ContainerBuilder builder, IModule repositoryModule, Action<IMapperConfigurationExpression> mapperExpression)
			where TContext : IdentityDbContext<TUser, TRole, TKey>
			where TUser : IdentityUser<TKey>
			where TRole : IdentityRole<TKey>
			where TKey : IEquatable<TKey>
		{
			var mapper = MapperConfigurator.Configure(mapperExpression);
			builder.RegisterInstance(mapper).As<IMapper>();

			builder.RegisterModule(repositoryModule);

			builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();

			builder.RegisterType<UserStore<TUser, TRole, TContext, TKey>>().As<IUserStore<TUser>>().InstancePerDependency();
			builder.RegisterType<RoleStore<TRole, TContext, TKey>>().As<IRoleStore<TRole>>().InstancePerDependency();
			builder.RegisterType<UserClaimsPrincipalFactory<TUser>>().As<IUserClaimsPrincipalFactory<TUser>>().InstancePerDependency();
			builder.RegisterType<UserManager<TUser>>().AsSelf().InstancePerDependency();
			builder.RegisterType<RoleManager<TRole>>().AsSelf().InstancePerDependency();

			builder.Register(context => new JwtTokenFactory()).As<JwtTokenFactory>().InstancePerDependency();
			builder.Register(context => new JwtTokenManager()).As<JwtTokenManager>().InstancePerDependency();

			builder.RegisterServices<TUser, TRole, TKey>();
		}

		public IServiceProvider CreateConfiguredServiceProvider<TContext, TUser, TRole, TKey>(IServiceCollection services, IModule repositoryModule, Action<IMapperConfigurationExpression> mapperExpression)
			where TContext : IdentityDbContext<TUser, TRole, TKey>
			where TUser : IdentityUser<TKey>
			where TRole : IdentityRole<TKey>
			where TKey : IEquatable<TKey>
		{
			var builder = new ContainerBuilder();
			Registertypes<TContext, TUser, TRole, TKey>(builder, repositoryModule, mapperExpression);

			builder.Populate(services);
			var applicationContainer = builder.Build();

			return new AutofacServiceProvider(applicationContainer);
		}
	}
}
