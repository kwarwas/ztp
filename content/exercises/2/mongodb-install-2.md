## Instalacja (docker) mongoDB

- Zainstalować Docker (https://www.docker.com)
- [Opcjonalnie] Pobrać obraz mongoDB z Docker Hub:

    
    docker pull mongo


- Uruchomić kontener docker na podstawie obrazu `mongo`:


    docker run -p 27017:27017 -d mongo


- Zainstalować narzędzie Robo 3T (https://robomongo.org)