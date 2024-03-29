﻿using System;
using MiniFac.Builder;
using MiniFac.Contract;
using MiniFac.Core.Lifetime;

namespace MiniFac.Extensions
{
    public static class RegistrationBuilderExtensions
    {
        public static IRegistrationBuilder<TLimit> RegisterType<TLimit>(
            this MiniContainerBuilder builder)
        {
            var rb = RegistrationBuilderFactory.ForType<TLimit>();

            builder.AddLazyConfiguration(c => RegistrationBuilderFactory.RegisterSingleComponent(c, rb));

            return rb;
        }

        public static IRegistrationBuilder<object> RegisterType(
            this MiniContainerBuilder builder, Type limitType)
        {
            var rb = RegistrationBuilderFactory.ForType(limitType);

            builder.AddLazyConfiguration(c => RegistrationBuilderFactory.RegisterSingleComponent(c, rb));

            return rb;
        }

        public static IRegistrationBuilder<TInstance> RegisterInstance<TInstance>(
            this MiniContainerBuilder builder, TInstance instance)
        {
            var rb = RegistrationBuilderFactory.ForInstance(instance);

            builder.AddLazyConfiguration(c => RegistrationBuilderFactory.RegisterSingleComponent(c, rb));

            return rb;
        }

        public static IRegistrationBuilder<TLimit> InstancePerLifetimeScope<TLimit>(
            this IRegistrationBuilder<TLimit> builder)
        {
            builder.RegistrationData.Sharing = InstanceSharing.Shared;
            builder.RegistrationData.Lifetime = new CurrentLifetimeScope();
            return builder;
        }

        public static IRegistrationBuilder<TLimit> SingleInstance<TLimit>(
            this IRegistrationBuilder<TLimit> builder)
        {
            builder.RegistrationData.Sharing = InstanceSharing.Shared;
            builder.RegistrationData.Lifetime = new RootLifetimeScope();
            return builder;
        }
    }
}
