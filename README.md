Syarat yang diperlukan:
- pengetahuan dasar cara menggunakan API tools dan cara menjalankan aplikasi dari source code
- pengetahuan dasar menjalankan query SQL
- dotnet runtime versi >= 8 sudah terinstall di operasi sistem
- microsoft visual studio terbaru beserta local/dedicate mssql sudah terinstal
- moderen web browser atau client API software

Tahapan:
- persiapkan database dengan menjalankan query pada file prepareIngredients.txt
- jalankan program dari source code dan buka web browser/client API dan arahkan URL ke salah satu dari 5 alamat berikut:
- GET http://localhost:3218/api/product URL ini berfungsi untuk menampilkan semua data yang ada di database
- GET http://localhost:3218/api/product/2 URL ini menampilkan satu data produk berdasarkan id
- POST http://localhost:3218/api/product URL ini berfungsi menambahkan satu data produk ke database
- PUT http://localhost:3218/api/product/2 URL ini untuk mengubah satu data produk berdasarkan id
- DELETE http://localhost:3218/api/product/2 URL ini untuk menghapus satu data produk berdasarkan id

Visi:
- reusable project
- microservices

Pernyataan Bantahan:
- dipersilahkan menggunakan, memodifikasi, dan menyebarluaskan aplikasi ini
- projek ini hanyalah sekedar latihan koding bagi kreator
- tidak diperlukan file presentasi seperti pada projek pertama karena dokumentasi ini sudah dirasa cukup dengan catatan sudah memenuhi persyaratan di atas
- happy koding!!!