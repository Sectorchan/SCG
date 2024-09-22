REM CA Private Key
openssl2.exe genrsa -aes256 -passout pass:test -out ../certificates/ca/private/qw.key.pem 4096
REM CA Private Key WSL
openssl genrsa -aes256 -passout pass:test -out certificates/ca/private/qw.key.pem 4096

REM CA Public Cert
openssl2.exe req -config openssl_ca.cnf -key certificates/ca/private/qw.key.pem -passin pass:test -new -x509 -days 7300 -sha256 -extensions v3_ca -out certificates/ca/certs/qw.cert.pem -subj "/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=Lang-CA/emailAddress=admin3@diefamilielang.de"
REM CA Public Cert WSL
openssl req -config openssl-ca.cnf -key certificates/ca/private/qw.key.pem -passin pass:test -new -x509 -days 7300 -sha256 -extensions v3_ca -out certificates/ca/certs/qw.cert.pem -subj "/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=Lang-CA/emailAddress=admin3@diefamilielang.de"

REM CA verification
openssl x509 -noout -text -in certificates/ca/certs/qw.cert.pem


REM Intermediate Private Key
openssl2.exe genrsa -aes256 -passout pass:test -out ../certificates/intermediate/private/int.key.pem 4096
REM Intermediate Private Key WSL
openssl genrsa -aes256 -passout pass:test2 -out certificates/intermediate/private/qwa.key.pem 4096

REM Intermediate CSR
openssl2.exe req -config ../certificates/intermediate/openssl.cnf -new -sha256 -key ../certificates/intermediate/private/int.key.pem -passin pass:test -out ../certificates/intermediate/csr/int.csr.pem -subj "/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=Lang-Intermediate/emailAddress=admin2@diefamilielang.de"
REM Intermediate CSR WSL
openssl req -config openssl-inter.cnf -new -passin pass:test2 -sha256 -key certificates/intermediate/private/qwa.key.pem -out certificates/intermediate/csr/qwa.csr.pem -subj "/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=Lang-Intermediate/emailAddress=admin-intermediate@diefamilielang.de"

REM Intermediate CSR sign with CA
openssl2.exe ca -config ../certificates/ca/openssl.cnf -passin pass:test -rand_serial -extensions v3_intermediate_ca -days 3650 -batch -notext -md sha256 -in ../certificates/intermediate/csr/int.csr.pem -out ../certificates/intermediate/certs/int.cert.pem 
REM Intermediate CSR sign with CA WSL
openssl ca -config openssl-ca.cnf -extensions v3_intermediate_ca -rand_serial -batch -days 3650 -notext -md sha256 -passin pass:test -in certificates/intermediate/csr/qwa.csr.pem -out certificates/intermediate/certs/qwa.cert.pem

REM Intermediate verification
openssl x509 -noout -text -in certificates/intermediate/certs/qwa.cert.pem

REM verificate Intermediate against CA
openssl verify -CAfile certificates/ca/certs/qw.cert.pem certificates/intermediate/certs/qwa.cert.pem

REM intermediiate CA chain
cat certificates/intermediate/certs/qwa.cert.pem certificates/ca/certs/qw.cert.pem > certificates/intermediate/certs/inter-ca-chain.cert.pem



REM Server private key
openssl2.exe  genrsa -aes256 -passout pass:test2 -out ../certificates/server/private/server2.key.pem 4096
REM Server private key WSL
 

REM Server Public CSR
openssl2.exe req -key ../certificates/server/private/server2.key.pem -passin pass:test2 -new -sha256 -out ../certificates/server/csr/server2.csr.pem -subj "/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=server/emailAddress=admin@diefamilielang.de/subjectAltName=DNS:server.lang, DNS:sl, IP:192.168.1.22"
REM Server Public CSR WSL
openssl req -config openssl-inter.cnf -key certificates/server/private/server.key.pem -new -sha256 -out certificates/server/csr/server.csr.pem -subj "/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=server/emailAddress=admin@diefamilielang.de/subjectAltName=DNS:server.lang, DNS:sl, IP:192.168.1.22"

REM Server public cert certifing
openssl2.exe ca -config ../certificates/server/openssl.cnf -passin pass:test -extensions server_cert -rand_serial -batch -days 375 -notext -md sha256 -in ../certificates/server/csr/server2.csr.pem -out ../certificates/server/certs/server2.cert.pem -subj "/C=DE/ST=Bavaria/L=Schwabhausen/O=Lang-Lan/OU=IT/CN=servercert/emailAddress=admin@diefamilielang.de/subjectAltName=DNS:servercert.lang, DNS:sc, IP:192.168.1.222"
REM Server public cert certifing WSL
openssl ca -config openssl-inter.cnf -extensions server_cert -passin pass:test2 -days 375 -batch -rand_serial -notext -md sha256 -in certificates/server/csr/server.csr.pem -out certificates/server/certs/server.cert.pem

pause
