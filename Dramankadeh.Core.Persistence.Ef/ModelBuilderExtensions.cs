using System.Reflection;
using Darmankadeh.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Dramankadeh.Core.Persistence.Ef;

public static class ModelBuilderExtensions
{
    private static void DisableIdentityGeneric<TEntity>(ModelBuilder modelBuilder)
        where TEntity : Entity
    {
        modelBuilder.Entity<TEntity>().Property(p => p.Id).ValueGeneratedNever();
    }

    private static void DisableIdentity(ModelBuilder modelBuilder, Type entityType)
    {
        var method = typeof(ModelBuilderExtensions)
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(t => t.Name == nameof(DisableIdentityGeneric));
        method.MakeGenericMethod(entityType)
            .Invoke(null, new object[] { modelBuilder });
    }

    public static void DisableIdentitySettingOnAllEntities(this ModelBuilder modelBuilder)
    {
        foreach (var type in modelBuilder.Model.GetEntityTypes())
            if (typeof(Entity).IsAssignableFrom(type.ClrType))
                DisableIdentity(modelBuilder, type.ClrType);
    }


    private static void ApplyRowVersionGeneric<TEntity>(ModelBuilder modelBuilder)
        where TEntity : Entity
    {
        modelBuilder.Entity<TEntity>().Property(c => c.RowVersion)
            .IsRequired()
            .IsRowVersion()
            .ValueGeneratedOnAddOrUpdate();
    }

    private static void ApplyRowVersion(ModelBuilder modelBuilder, Type entityType)
    {
        var method = typeof(ModelBuilderExtensions)
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(t => t.Name == nameof(ApplyRowVersionGeneric));
        method.MakeGenericMethod(entityType)
            .Invoke(null, new object[] { modelBuilder });
    }

    public static void ApplyRowVersionSettingOnAllEntities(this ModelBuilder modelBuilder)
    {
        foreach (var type in modelBuilder.Model.GetEntityTypes())
            if (typeof(Entity).IsAssignableFrom(type.ClrType))
                ApplyRowVersion(modelBuilder, type.ClrType);
    }


    private static void SetIdAsKeyGeneric<TEntity>(ModelBuilder modelBuilder)
        where TEntity : Entity
    {
        modelBuilder.Entity<TEntity>().HasKey(p => p.Id);
    }

    private static void SetIdAsKey(ModelBuilder modelBuilder, Type entityType)
    {
        var method = typeof(ModelBuilderExtensions)
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(t => t.Name == nameof(SetIdAsKeyGeneric));
        method.MakeGenericMethod(entityType)
            .Invoke(null, new object[] { modelBuilder });
    }

    public static void SetIdAsKeyOnAllEntities(this ModelBuilder modelBuilder)
    {
        foreach (var type in modelBuilder.Model.GetEntityTypes())
            if (type.ClrType.BaseType == typeof(Entity))
                SetIdAsKey(modelBuilder, type.ClrType);
    }


    private static void IgnorePropertyGeneric<TEntity>(ModelBuilder modelBuilder, string property)
        where TEntity : Entity
    {
        modelBuilder.Entity<TEntity>().Ignore(property);
    }

    private static void IgnoreProperty(ModelBuilder modelBuilder, Type entityType, string property)
    {
        var method = typeof(ModelBuilderExtensions)
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .Single(t => t.Name == nameof(IgnorePropertyGeneric));
        method.MakeGenericMethod(entityType)
            .Invoke(null, new object[] { modelBuilder, property });
    }

    public static void IgnorePropertyOnAllEntities(this ModelBuilder modelBuilder, string property)
    {
        foreach (var type in modelBuilder.Model.GetEntityTypes())
            if (typeof(Entity).IsAssignableFrom(type.ClrType))
                IgnoreProperty(
                    modelBuilder,
                    type.ClrType,
                    property);
    }
}