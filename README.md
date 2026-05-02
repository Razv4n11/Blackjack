# BlackJack (Unity)

A Blackjack game made with **Unity**, featuring **bet selection** and **locally stored money permanence** (your bankroll is saved on your device between sessions).

## Features

- Classic Blackjack gameplay
- **Bet selection** before playing a hand
- **Persistent money/bankroll saved locally** (progress carries over between runs)

## Requirements

- **Unity Editor:** `6000.3.0f1` (recommended)
- A Unity-supported OS (Windows/macOS/Linux)

> If you open the project in a different Unity version, Unity may upgrade/downgrade packages and project settings.

## Getting Started (Run the project)

1. Clone the repository:
   ```bash
   git clone https://github.com/Razv4n11/BlackJack.git
   ```
2. Open **Unity Hub**
3. Click **Add** → select the cloned `BlackJack` folder
4. Open the project with **Unity 6000.3.0f1**
5. In the Project window, open the main scene (under `Assets/Scenes/`)
6. Press **Play**

## Project Structure

- `Assets/` — game assets, scripts, scenes, prefabs, etc.
- `Packages/` — Unity package manifest and package settings
- `ProjectSettings/` — Unity project configuration

## Notes

- This repository includes Unity package dependencies via `Packages/manifest.json`.
- If Unity prompts you about missing packages, allow it to resolve/download them.
- Money persistence is stored **locally** (not synced online).
