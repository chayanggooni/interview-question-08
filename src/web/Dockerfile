FROM node:22-alpine AS build

WORKDIR /app

COPY src/web/package*.json ./

RUN npm ci

COPY src/web/ .

RUN npm run build


FROM nginx:alpine

COPY src/web/nginx.conf /etc/nginx/conf.d/default.conf

COPY --from=build /app/dist/web/browser /usr/share/nginx/html

EXPOSE 80