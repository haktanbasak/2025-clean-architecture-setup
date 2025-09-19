# 2025 Yýlý Clean Architecture Setup

Bu repoda 2025 yýlý için projelerimizde baþlangýç olarak kullanabileceðimiz bir yapý tasarlandý. 

## Proje Ýçeriði

### Mimari Yapý
- **Architectural Pattern**: Clean Architecture
- **Design Patterns**: 
	- Result Pattern
	- Repository Pattern
	- CQRS Pattern
	- Unit of Work Pattern
*** Kullanýlan Kütüphaneler:
- **MediatR**: CQRS ve mesajlaþma iþlemleri için.
- **TS.Result**: Standart sonuç yapýsý için.
- **Mapster**: Nesne dönüþümleri için.
- **FluentValidation**: Doðrulama iþlemleri için.
- **TS.EntityFrameworkCore.GenericRepository**: Genel amaçlý repository iþlemleri için.
- **EntityFrameworkCore**: ORM için
- **OData**: Sorgulama ve veri eriþiminde esneklik saðlamak için.
- **Scrutor**: Dependency Injection yönetimi ve dinamik servis kayýtlarý için.

*** Kurulum ve Kullaným:
1. **Depoyu Klonlayýn**: 
   ```bash
   git clone https://github.com/haktanbasak/2025-clean-architecture-setup.git
   cd 2025-clean-architecture-setup
   
