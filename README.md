# BlackJack (Unity) — Mobile

A **mobile** Blackjack game made with **Unity**, featuring **bet selection** and **locally stored money permanence** (your bankroll is saved on your device between sessions).

## Features

- Mobile-focused Blackjack gameplay
- **Bet selection** before each hand
- **Persistent money/bankroll saved locally** (progress carries over between runs)

## Download / Install (APK)

A **pre-built Android APK** is included in this repository.

1. Download the `.apk` from the repo
2. Transfer it to your Android phone
3. On Android, enable installing from unknown sources:
   - **Settings → Security/Privacy → Install unknown apps**
4. Open the APK and install

## Getting Started (Open in Unity)

1. Clone the repository:
   ```bash
   git clone https://github.com/Razv4n11/BlackJack.git
   ```
2. Open **Unity Hub**
3. Click **Add** → select the cloned `BlackJack` folder
4. Open the project with **Unity 6000.3.0f1**
5. Open the main scene (under `Assets/Scenes/`)
6. Press **Play**

## Building for Mobile (Android/iOS)

1. In Unity: **File → Build Settings**
2. Select **Android** or **iOS**
3. Click **Switch Platform**
4. Configure player settings as needed, then **Build** / **Build And Run**

## Project Structure

- `Assets/` — game assets, scripts, scenes, prefabs, etc.
- `Packages/` — Unity package manifest and package settings
- `ProjectSettings/` — Unity project configuration

## Notes

- This repository includes Unity package dependencies via `Packages/manifest.json`.
- If Unity prompts you about missing packages, allow it to resolve/download them.
- Money persistence is stored **locally** (not synced online).
