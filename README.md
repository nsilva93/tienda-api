# Tienda API – Backend (ASP.NET Core 3.1)

API desarrollada como parte del examen técnico para la vacante de **Desarrollador .NET**.  
Implementa una arquitectura en **4 capas**, autenticación mediante **JWT**, CRUDs completos y relaciones entre entidades.

---

# Características principales

 API en **ASP.NET Core 3.1**  
 Arquitectura **4 capas**:  
 **Entities (Modelos)**  
 **Data (EF Core / Repositorios)**  
 **Business (Servicios)**  
 **API (Controllers)**  

 CRUD completo para:
 **Tiendas**
 **Artículos**
 **Clientes**
 **Relación Cliente–Artículo**
 **Relación Tienda–Artículo**

 Autenticación con **JWT**  
 Manejo de excepciones  
 Validaciones básicas  
 Proyecto 100% funcional  

---

# Requisitos

| Requisito | Versión |
|----------|----------|
| .NET Core SDK | **3.1** |
| SQL Server | Cualquier versión |
| Entity Framework Core | 3.x |
| Visual Studio 2019 o superior | ✅ |

---

BASE DE DATOS
´´´
USE [TiendaDb]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 09/11/2025 09:34:54 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articulos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Precio] [decimal](18, 2) NOT NULL,
	[Imagen] [nvarchar](max) NULL,
	[Stock] [int] NOT NULL,
 CONSTRAINT [PK_Articulos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClienteArticulos]    Script Date: 09/11/2025 09:34:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClienteArticulos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[ArticuloId] [int] NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ClienteArticulos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 09/11/2025 09:34:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Apellidos] [nvarchar](max) NULL,
	[Direccion] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[PasswordHash] [nvarchar](max) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiendaArticulos]    Script Date: 09/11/2025 09:34:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiendaArticulos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TiendaId] [int] NOT NULL,
	[ArticuloId] [int] NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TiendaArticulos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tiendas]    Script Date: 09/11/2025 09:34:55 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tiendas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sucursal] [nvarchar](max) NULL,
	[Direccion] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tiendas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ClienteArticulos]  WITH CHECK ADD  CONSTRAINT [FK_ClienteArticulos_Articulos_ArticuloId] FOREIGN KEY([ArticuloId])
REFERENCES [dbo].[Articulos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClienteArticulos] CHECK CONSTRAINT [FK_ClienteArticulos_Articulos_ArticuloId]
GO
ALTER TABLE [dbo].[ClienteArticulos]  WITH CHECK ADD  CONSTRAINT [FK_ClienteArticulos_Clientes_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ClienteArticulos] CHECK CONSTRAINT [FK_ClienteArticulos_Clientes_ClienteId]
GO
ALTER TABLE [dbo].[TiendaArticulos]  WITH CHECK ADD  CONSTRAINT [FK_TiendaArticulos_Articulos_ArticuloId] FOREIGN KEY([ArticuloId])
REFERENCES [dbo].[Articulos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TiendaArticulos] CHECK CONSTRAINT [FK_TiendaArticulos_Articulos_ArticuloId]
GO
ALTER TABLE [dbo].[TiendaArticulos]  WITH CHECK ADD  CONSTRAINT [FK_TiendaArticulos_Tiendas_TiendaId] FOREIGN KEY([TiendaId])
REFERENCES [dbo].[Tiendas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TiendaArticulos] CHECK CONSTRAINT [FK_TiendaArticulos_Tiendas_TiendaId]
GO
