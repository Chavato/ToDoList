# Etapa de compilação
FROM node:latest as build-step
WORKDIR /app
COPY package.json /app
RUN npm install
COPY . .
RUN npm run build

# Etapa de execução
FROM nginx:latest 
COPY --from=build-step /app/dist/to-do-list-web/browser /usr/share/nginx/html