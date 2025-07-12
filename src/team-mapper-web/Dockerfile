# Use Node.js 18 with Alpine Linux as the base image (lightweight)
FROM node:18-alpine

# Set the working directory inside the container
WORKDIR /app

# Copy package files first to leverage Docker cache
COPY src/team-mapper-web/package.json  ./

# Install dependencies, disable SSL strict mode for npm
RUN npm config set strict-ssl false && npm install

# Copy application source code
COPY src/team-mapper-web/package-lock.json  ./
COPY src/team-mapper-web/public/ ./public
COPY src/team-mapper-web/src/ ./src

# Set the port environment variable
ENV PORT=3001w

# Expose port 3001 for the application
EXPOSE 3001

# Command to start the application using npm start
CMD ["npm", "start"]

# Add healthcheck instruction
HEALTHCHECK --interval=30s --timeout=10s --start-period=5s --retries=3 \
  CMD curl --fail http://localhost:3001/health || exit 1