Bu projenin amacı endpoint e gönderilen faturaya aşağı belirtilen şartlarda indirim uygulamaktır.
Code-First mantığı ile MinimalAPI, EntityFrameWorkCore kullanılarak geliştirildi. 
İndirim şartları CustomerType endpoint ine girilerek oluşturulur. Case istenen şartlar:
-Kullanıcı mağazanın çalışanı ise %30 indirim alır.
-Kullanıcı mağazanın satış ortağı ise %10 indirim alır.
-Kullanıcı 2 yılı aşkın süredir müşteri ise %5 indirim alır.
-CustomerType endpoint ine yeni kayıtlar girilerek yüzdelik indirim seçenekleri çoğaltılabilir.

Yüzdelik indirimler Invoice endpoint inin response unda "discountForPercent" ile gösterilir.

Ayrıca her faturaya 100 tl için 5 tl indirim olacaktır. Örneğin 990 tl için 45 tl indirim yapılır. Invoice endpoint inin response unda "discountPer100" ile gösterilir.

Market alışverişlerinde yüzde bazlı indirimler uygulanmaz. Bu Invoice endpoint inde "isGrocery" alanı ile kontrol edilir; isGrocery = true ise market alışverişi, false ise market alışverişi değildir.

# ShopRUs-Discount-App
+------------------------------------+
|              Invoice               |
+------------------------------------+
| - invoiceNumber: string            |
| - customerId: int                  |
| - description: string              |
| - discountPer100: double           |
| - discountForPercent: double       |
| - totalDiscount: double             |
| - totalPrice: double               |
| - totalNet: double                  |
| - invoiceDate: DateTime            |
| - isGrocery: bool                  |
+------------------------------------+

+------------------------------------+
|           CustomerType             |
+------------------------------------+
| - typeName: string                 |
| - discountPercent: double          |
+------------------------------------+

+------------------------------------+
|             Customers              |
+------------------------------------+
| - nationalId: string               |
| - name: string                     |
| - surName: string                  |
| - createdDate: DateTime            |
| - customerTypeId: int               |
+------------------------------------+


CustomerType için gerekli request:
{
  "typeName": "string",
  "discountPercent": 0
}

Customer için gerekli request:
{
  "nationalId": "string",
  "name": "string",
  "surName": "string",
  "createdDate": "2023-10-03T20:50:48.984Z",
  "customerTypeId": 0
}

Invoice için gerekli request:
{
  "invoiceNumber": "string",
  "customerId": 0,
  "description": "string",
  "discountPer100": 0,
  "discountForPercent": 0,
  "totalDiscount": 0,
  "totalPrice": 0,
  "totalNet": 0,
  "invoiceDate": "2023-10-03T21:14:18.837Z",
  "isGrocery": true
}

