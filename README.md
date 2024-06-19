# MovieList

MovieList is a simple Windows Forms application that displays a list of movies from a specified directory. Each movie is displayed with its title and cover image, and clicking on a movie opens it in the default media player.

## Features

- **Automatic Movie Detection:** Scans a specified directory for movie files with extensions `.mkv`, `.mp4`, and `.avi`.
- **Cover Image Display:** Displays cover images for each movie (supports `.jpeg`, `.jpg`, `.png`, and `.bmp` formats).
- **Clickable Movies:** Opens the movie file in the default media player when clicked.
- **Customizable Layout:** Movies are displayed in a `FlowLayoutPanel` with a vertical layout and a fixed single-line border.

## Installation

1. Clone the repository:

2. Open the solution in Visual Studio.

3. Build the project:
    - Right-click on the solution in the Solution Explorer.
    - Select `Build`.

4. Publish the project:
    - Right-click on the project in the Solution Explorer.
    - Select `Publish` and follow the prompts to create an executable.

## Usage

1. On first run, the application will prompt you to select the directory containing your movie files.
2. The application will create a "Covers" folder in the selected directory if it does not already exist.
3. Ensure that cover images are named to match their respective movie files.
4. Hovering over a movie's cover image changes the cursor to a pointing hand.
5. Click on a movie to open it in your default media player.

