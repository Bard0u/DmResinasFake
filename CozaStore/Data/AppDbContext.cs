using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CozaStore.Models;

namespace CozaStore.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Carrinho> Carrinhos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Cor> Cores { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Tamanho> Tamanhos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<CarrinhoProduto> CarrinhoProdutos { get; set; }
    public DbSet<ListaDesejo> ListaDesejos { get; set; }
    public DbSet<ProdutoAvaliacao> ProdutoAvaliacaos { get; set; }
    public DbSet<ProdutoCategoria> ProdutoCategorias { get; set; }
    public DbSet<ProdutoEstoque> ProdutoEstoques { get; set; }
    public DbSet<ProdutoFoto> ProdutoFotos { get; set; }
    public DbSet<ProdutoTag> ProdutoTags { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Chave Primaria Composta - ProdutoFoto
        builder.Entity<ProdutoFoto>().HasKey(
            pf => new { pf.Id, pf.ProdutoId }
        );
        #endregion

        #region Relacionamento Muitos para Muitos - ProdutoAvaliacao

        builder.Entity<ProdutoAvaliacao>().HasKey(
            pa => new { pa.ProdutoId, pa.UsuarioId }
        );

        builder.Entity<ProdutoAvaliacao>()
            .HasOne(pa => pa.Produto)
            .WithMany(P => P.Avaliacoes)
            .HasForeignKey(pa => pa.ProdutoId);

        builder.Entity<ProdutoAvaliacao>()
            .HasOne(pa => pa.Usuario)
            .WithMany(u => u.Avaliacoes)
            .HasForeignKey(pa => pa.UsuarioId);
        #endregion

        #region Relacionamento Muitos para Muitos - ProdutoCategoria

        builder.Entity<ProdutoCategoria>().HasKey(
            pa => new { pa.ProdutoId, pa.CategoriaId }
        );

        builder.Entity<ProdutoCategoria>()
            .HasOne(pc => pc.Produto)
            .WithMany(c => c.Categorias)
            .HasForeignKey(pc => pc.ProdutoId);
        builder.Entity<ProdutoCategoria>()
            .HasOne(pc => pc.Categoria)
            .WithMany(c => c.Produtos)
            .HasForeignKey(pc => pc.CategoriaId);
        #endregion

        #region Relacionamento Muitos para Muitos - ProdutoTag

         builder.Entity<ProdutoTag>().HasKey(
            pa => new { pa.ProdutoId, pa.TagId }
        );

        builder.Entity<ProdutoTag>()
            .HasOne(pt => pt.Produto)
            .WithMany(t => t.Tags)
            .HasForeignKey(pt => pt.ProdutoId);
        builder.Entity<ProdutoTag>()
            .HasOne(pt => pt.Tag)
            .WithMany(t => t.Produtos)
            .HasForeignKey(pt => pt.TagId);

        #endregion

        #region Relacionamento Muitos para Muitos - ProdutoEstoque

        #endregion

    }
}
