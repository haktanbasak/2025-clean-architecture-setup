# 2025 Y�l� Clean Architecture Setup

Bu repoda 2025 y�l� i�in projelerimizde ba�lang�� olarak kullanabilece�imiz bir yap� tasarland�. 

## Proje ��eri�i

### Mimari Yap�
- **Architectural Pattern**: Clean Architecture
- **Design Patterns**: 
	- Result Pattern
	- Repository Pattern
	- CQRS Pattern
	- Unit of Work Pattern
*** Kullan�lan K�t�phaneler:
- **MediatR**: CQRS ve mesajla�ma i�lemleri i�in.
- **TS.Result**: Standart sonu� yap�s� i�in.
- **Mapster**: Nesne d�n���mleri i�in.
- **FluentValidation**: Do�rulama i�lemleri i�in.
- **TS.EntityFrameworkCore.GenericRepository**: Genel ama�l� repository i�lemleri i�in.
- **EntityFrameworkCore**: ORM i�in
- **OData**: Sorgulama ve veri eri�iminde esneklik sa�lamak i�in.
- **Scrutor**: Dependency Injection y�netimi ve dinamik servis kay�tlar� i�in.

*** Kurulum ve Kullan�m:
1. **Depoyu Klonlay�n**: 
   ```bash
   git clone https://github.com/haktanbasak/2025-clean-architecture-setup.git
   cd 2025-clean-architecture-setup
   
