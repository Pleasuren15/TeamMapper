# Use Node.js 18 with Alpine Linux as the base image (lightweight)
FROM node:18-alpine

# Set the working directory inside the container
WORKDIR /app

# Copy package files first to leverage Docker cache
COPY package.json package-lock.json ./
# Install dependencies, disable SSL strict mode for npm
RUN npm config set strict-ssl false && npm install

# Copy application source code
COPY public/ ./public
COPY src/ ./src

# Expose port 3000 for the application
EXPOSE 3000

# Command to start the application using npm start
CMD ["npm", "start"]