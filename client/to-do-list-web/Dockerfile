# Etapa de compilação
FROM node:latest as build-step
WORKDIR /app
COPY package.json ./
RUN npm install
COPY . .
RUN npm run build

# Etapa de execução
FROM nginx:alpine
COPY --from=build-step /app/dist/to-do-list-web /usr/share/nginx/html
COPY nginx.conf /etc/nginx/nginx.conf