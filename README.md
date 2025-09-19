# 2025 Yılı Clean Architecture Setup

Bu repoda 2025 yılı için projelerimizde başlangıç olarak kullanabileceğimiz bir yapı tasarlandı. 

## Proje İçeriği

### Mimari Yapı
- **Architectural Pattern**: Clean Architecture
- **Design Patterns**: 
	- Result Pattern
	- Repository Pattern
	- CQRS Pattern
	- Unit of Work Pattern
*** Kullanılan Kütüphaneler:
- **MediatR**: CQRS ve mesajlaşma işlemleri için.
- **TS.Result**: Standart sonuç yapısı için.
- **Mapster**: Nesne dönüşümleri için.
- **FluentValidation**: Doğrulama işlemleri için.
- **TS.EntityFrameworkCore.GenericRepository**: Genel amaçlı repository işlemleri için.
- **EntityFrameworkCore**: ORM için
- **OData**: Sorgulama ve veri erişiminde esneklik sağlamak için.
- **Scrutor**: Dependency Injection yönetimi ve dinamik servis kayıtları için.

### Kurulum ve Kullanım:
1. **Depoyu Klonlayın**: 
   ```bash
   git clone https://github.com/haktanbasak/2025-clean-architecture-setup.git
   cd 2025-clean-architecture-setup
   
