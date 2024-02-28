Project Overview
This project consists of three ASP.NET Core APIs - Auth, Chat, and Game - along with a React client application. The APIs are designed to handle authentication, real-time chat functionality, and gaming features, while the React client provides a user-friendly interface to interact with these services.

Technologies Used
ASP.NET Core for backend API development
React for frontend client development
SignalR for real-time communication in the chat module
Entity Framework Core for database interactions
JWT for authentication and authorization
HTML, CSS, and JavaScript for client-side development
Installation
Clone this repository to your local machine.
Navigate to the root directory of each API (Auth, Chat, and Game) and execute dotnet build to build the projects.
Run dotnet run to start each API. Ensure they are running on separate ports (by default, Auth runs on port 5032, Chat on port 7112, and Game on port 5287).
Navigate to the client directory and run npm install to install dependencies.
Once the dependencies are installed, execute npm start to run the React client.
Usage
Auth API: Handles user authentication and authorization. Provides endpoints for user registration, login, and token generation.
Chat API: Implements real-time chat functionality using SignalR. Users can join chat rooms, send messages, and receive real-time updates.
Game API: Provides endpoints for game-related features such as creating a game, making moves, and retrieving game state.
Configuration
Each API contains its own appsettings.json file where configuration settings such as database connection strings, authentication options, and SignalR settings can be customized.
The React client's configuration can be found in the client/src/config.js file, where you can specify the base URLs for the APIs.
Contributing
Contributions are welcome! If you find any bugs or have suggestions for improvements, please open an issue or submit a pull request.

License
This project is licensed under the MIT License. See the LICENSE file for more information.

Credits
Developed by [Your Name]
Inspired by [Any inspirations, libraries, or resources used]
Contact
For any inquiries or support, please contact [Your Email Address].
