# Unity Project Setup Guide

## Prerequisites

1. **Unity Hub** - Download from unity.com
2. **Unity Editor** - Version 2021.3 LTS or newer
3. **Text Editor** - Visual Studio Code (recommended) or Visual Studio

---

## Initial Setup Steps

### 1. Create New Unity Project

1. Open Unity Hub
2. Click "New Project"
3. Select **2D (Core)** template
4. Name: `HeraniyaJourney`
5. Location: This repository folder
6. Click "Create Project"

### 2. Configure Project Settings

#### Player Settings
`Edit > Project Settings > Player`

- **Company Name:** Your Name/Studio
- **Product Name:** Heraniya's Journey to See Somdev
- **Default Icon:** (Add icon when ready)
- **Bundle Identifier:**
  - iOS: `com.yourname.heraniyajourney`
  - Android: `com.yourname.heraniyajourney`

#### Quality Settings
`Edit > Project Settings > Quality`

- Set **Default Quality Level** to "Medium" for mobile
- Disable unnecessary quality levels

#### Physics 2D Settings
`Edit > Project Settings > Physics 2D`

- Create layers:
  - Layer 6: `Ground`
  - Layer 7: `Player`
  - Layer 8: `Collectibles`
  - Layer 9: `Vehicles`
  - Layer 10: `Obstacles`

---

## Import Scripts

All scripts are already created in `Assets/Scripts/`:

### Core Scripts
- ✅ GameManager.cs
- ✅ GameSettings.cs
- ✅ InputHandler.cs
- ✅ AudioManager.cs
- ✅ SaveSystem.cs

### Gameplay Scripts
- ✅ PlayerController.cs
- ✅ CollectionSystem.cs
- ✅ Collectible.cs
- ✅ VehicleController.cs

These scripts are ready to use once you open the project in Unity!

---

## Scene Setup

### 1. Create Main Menu Scene

1. `File > New Scene`
2. Save as `Scenes/MainMenu.unity`
3. Add UI Canvas
4. Add GameManager prefab

### 2. Create Level 1 (Living Room)

1. `File > New Scene`
2. Save as `Scenes/Level1_LivingRoom.unity`
3. Add:
   - Main Camera (tag: MainCamera)
   - GameManager (with GameManager.cs)
   - InputHandler (with InputHandler.cs)
   - AudioManager (with AudioManager.cs)
   - CollectionSystem (with CollectionSystem.cs)

---

## Creating Player Character

### 1. Create Player GameObject

1. Create Empty GameObject, name: `Heraniya`
2. Add components:
   - `Sprite Renderer` (add placeholder sprite)
   - `Rigidbody2D`:
     - Body Type: Dynamic
     - Mass: 1
     - Linear Drag: 0
     - Angular Drag: 0.05
     - Gravity Scale: 3
     - Freeze Rotation Z: ✓
   - `Box Collider 2D` (adjust size to sprite)
   - `Animator` (will add later)
   - `PlayerController` script

3. Create child GameObject: `GroundCheck`
   - Position slightly below player feet
   - This is used for ground detection

4. Assign in PlayerController:
   - Ground Check: Drag `GroundCheck` child
   - Ground Layer: Select `Ground` layer

### 2. Player Settings

In PlayerController component:
- Walk Speed: 2
- Run Speed: 3
- Jump Force: 10
- Allow Double Jump: ✓
- Coyote Time: 0.2
- Jump Buffer Time: 0.2
- Ground Check Radius: 0.2

---

## Creating Ground

1. Create Sprite > Square
2. Name: `Ground`
3. Scale: X=10, Y=1, Z=1
4. Add `Box Collider 2D`
5. Set Layer to `Ground`
6. Position below player

---

## Creating Collectibles

### Star Collectible

1. Create Empty GameObject: `Star`
2. Add components:
   - `Sprite Renderer` (yellow star sprite)
   - `Circle Collider 2D` (Is Trigger: ✓)
   - `Collectible` script
3. In Collectible script:
   - Type: Star
   - Value: 1
   - Auto Collect Radius: 1
4. Save as Prefab: `Prefabs/Collectibles/Star.prefab`

Repeat for Cookie and Heart with respective settings.

---

## Creating Vehicle

### Toy Car

1. Create Empty GameObject: `ToyCar`
2. Add components:
   - `Sprite Renderer` (car sprite)
   - `Box Collider 2D` (Is Trigger: ✓)
   - `VehicleController` script
3. Create child: `MountPoint` (where player sits)
4. In VehicleController:
   - Vehicle Type: ToyCar
   - Speed Multiplier: 1.5
   - Jump Multiplier: 1.33
   - Rider Position: (0, 0.5, 0)
5. Save as Prefab: `Prefabs/Vehicles/ToyCar.prefab`

---

## Build Settings

### Add Scenes to Build

`File > Build Settings`

1. Add scenes in order:
   - MainMenu.unity
   - Level1_LivingRoom.unity
   - Level2_Hallway.unity (when created)
   - Level3_Bedroom.unity (when created)

### Platform Configuration

#### iOS
- Switch Platform to iOS
- Set Bundle Identifier
- Set minimum iOS version: 13.0

#### Android
- Switch Platform to Android
- Set Package Name
- Minimum API Level: 26 (Android 8.0)
- Target API Level: Latest

---

## Testing the Prototype

### 1. Basic Movement Test

1. Press Play in Unity Editor
2. Press Space or Click anywhere
3. Player should jump
4. Player should auto-walk right

### 2. Collection Test

1. Place Star collectible in scene
2. Press Play
3. Walk into star
4. Check console for collection message

### 3. Vehicle Test

1. Place ToyCar in scene
2. Press Play
3. Walk to car
4. Should auto-mount
5. Speed should increase

---

## Common Issues & Solutions

### Player falls through ground
- Check that Ground has `Box Collider 2D`
- Check that Ground layer is set correctly
- Check that Player's Ground Layer mask includes Ground

### Jump doesn't work
- Check that InputHandler is in scene
- Check that PlayerController is receiving events
- Check Jump Force is > 0

### Collectibles don't collect
- Check Circle Collider 2D is set to Trigger
- Check Player has correct tag ("Player")
- Check CollectionSystem is in scene

### No audio
- Check AudioManager is in scene
- Check audio clips are assigned
- Check volumes are not 0
- Check Baby-Safe Mode is off

---

## Next Steps

1. ✅ Set up Unity project
2. ✅ Import all scripts
3. ⬜ Create basic test scene
4. ⬜ Create placeholder sprites
5. ⬜ Test core mechanics
6. ⬜ Create Level 1 layout
7. ⬜ Add audio files
8. ⬜ Create UI menus
9. ⬜ Implement full gameplay loop
10. ⬜ Build and test on device

---

## Placeholder Art

Until final art is ready, use these placeholder shapes:

- **Heraniya:** Pink square (128x128)
- **Ground:** Brown rectangle
- **Star:** Yellow circle
- **Cookie:** Brown circle
- **Heart:** Pink circle
- **Car:** Red rectangle
- **Scooter:** Blue rectangle

Create these in any image editor or use Unity's built-in sprites.

---

## Useful Unity Shortcuts

- **Play:** Ctrl/Cmd + P
- **Pause:** Ctrl/Cmd + Shift + P
- **Frame Selected:** F
- **Scene View:** Ctrl/Cmd + 1
- **Game View:** Ctrl/Cmd + 2
- **Duplicate:** Ctrl/Cmd + D
- **Save:** Ctrl/Cmd + S

---

**Ready to start building!** 🎮

For questions, refer to:
- [Unity Documentation](https://docs.unity3d.com/)
- [Game Design Document](../docs/GAME_DESIGN.md)
- [Technical Specification](../docs/TECHNICAL_SPEC.md)
