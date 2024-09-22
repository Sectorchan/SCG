REM Delete all PEM files
rmdir /s /q ..\certificates

mkdir ..\certificates
mkdir  ..\certificates\ca
mkdir  ..\certificates\ca\certs
mkdir  ..\certificates\ca\crl
mkdir  ..\certificates\ca\newcerts
mkdir  ..\certificates\ca\private
type nul >  ..\certificates\ca\index.txt
type nul >  ..\certificates\ca\serial

mkdir  ..\certificates\intermediate
mkdir  ..\certificates\intermediate\certs
mkdir  ..\certificates\intermediate\crl
mkdir  ..\certificates\intermediate\csr
mkdir  ..\certificates\intermediate\newcerts
mkdir  ..\certificates\intermediate\private
type nul >  ..\certificates\intermediate\index.txt
type nul >  ..\certificates\intermediate\serial

mkdir  ..\certificates\server
mkdir  ..\certificates\server\certs
mkdir  ..\certificates\server\csr
mkdir  ..\certificates\server\newcerts
mkdir  ..\certificates\server\private
type nul >  ..\certificates\server\index.txt
type nul >  ..\certificates\server\serial

copy /y openssl-ca.cnf certificates\ca\openssl.cnf
copy /y openssl-inter.cnf certificates\intermediate\openssl.cnf
copy /y openssl-sere.cnf certificates\server\openssl.cnf
