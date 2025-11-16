# Unity Project Checklist

Quick reference for Unity setup progress.

---

## 📥 Installation

- [ ] Unity Hub installed
- [ ] Unity 2021.3 LTS (or newer) installed
- [ ] 2D Development module added
- [ ] iOS Build Support added (optional)
- [ ] Android Build Support added (optional)
- [ ] Code editor installed (VS Code or Visual Studio)

---

## 🆕 Project Creation

- [ ] Created new 2D (Core) project
- [ ] Project name: `HeraniyaJourney`
- [ ] Project location: This repository folder
- [ ] Project opens successfully

---

## ⚙️ Project Settings

- [ ] Company Name set
- [ ] Product Name set
- [ ] Bundle Identifier set (iOS)
- [ ] Bundle Identifier set (Android)
- [ ] Quality Level set to Medium
- [ ] Layers created (Ground, Player, Collectibles, Vehicles, Obstacles)
- [ ] Tags created (Player, Collectible, Vehicle)

---

## 📁 Project Structure

- [ ] Assets/Scenes/ folder exists
- [ ] Assets/Scripts/ contains our 9 scripts
- [ ] Assets/Prefabs/ folder created
- [ ] Assets/Sprites/ folder created
- [ ] Assets/Audio/ folder created
- [ ] All scripts imported without errors

---

## 🎬 Scene Setup

- [ ] TestScene created and saved
- [ ] Scene added to Build Settings
- [ ] Camera positioned correctly
- [ ] Lighting looks good

---

## 🎮 Game Managers

- [ ] GameManager GameObject created
- [ ] GameManager.cs attached
- [ ] InputHandler.cs attached
- [ ] AudioManager.cs attached
- [ ] CollectionSystem.cs attached

---

## 👤 Player Character

- [ ] Heraniya GameObject created
- [ ] Sprite Renderer added (pink square)
- [ ] Rigidbody2D added and configured
- [ ] Box Collider2D added
- [ ] PlayerController.cs attached
- [ ] GroundCheck child created
- [ ] GroundCheck assigned to script
- [ ] Player tag set
- [ ] Player layer set
- [ ] Ground Layer set in PlayerController

---

## 🟩 Ground

- [ ] Ground GameObject created
- [ ] Sprite set to Square
- [ ] Scaled appropriately (20x1)
- [ ] Box Collider2D added
- [ ] Ground layer set
- [ ] Player can stand on ground

---

## 🎯 Core Gameplay Tests

- [ ] Player falls with gravity
- [ ] Player lands on ground
- [ ] Player doesn't rotate
- [ ] SPACE makes player jump
- [ ] Click makes player jump
- [ ] Jump height feels good
- [ ] No errors in Console during play

---

## ⭐ Collectibles

- [ ] Star GameObject created
- [ ] Sprite Renderer configured (yellow)
- [ ] Circle Collider2D added (Is Trigger checked)
- [ ] Collectible.cs attached
- [ ] Collectible Type set to Star
- [ ] Star prefab created
- [ ] Player can collect stars
- [ ] Collection message shows in Console
- [ ] Counter updates

---

## 📱 UI (Optional)

- [ ] Canvas created
- [ ] Canvas configured (Screen Space Overlay)
- [ ] TextMeshPro imported
- [ ] Star counter text created
- [ ] Counter positioned (top-left)
- [ ] Counter updates when collecting

---

## 🎨 Polish (Optional for now)

- [ ] Background sprite added
- [ ] Ground has texture
- [ ] Player has custom sprite
- [ ] Collectibles have glow effect
- [ ] Camera follows player
- [ ] Audio clips added

---

## 🔨 Prefabs Created

- [ ] Star prefab
- [ ] Cookie prefab
- [ ] Heart prefab
- [ ] Player prefab (optional)
- [ ] Ground prefab (optional)

---

## 🚗 Vehicles (Future)

- [ ] Toy Car GameObject created
- [ ] VehicleController.cs attached
- [ ] Mount point configured
- [ ] Car prefab created
- [ ] Scooter GameObject created
- [ ] Scooter prefab created
- [ ] Mounting works
- [ ] Speed boost works

---

## 🎵 Audio (Future)

- [ ] Music tracks imported
- [ ] SFX imported
- [ ] AudioManager has clips assigned
- [ ] Jump sound plays
- [ ] Collection sound plays
- [ ] Background music plays

---

## 📱 Build Settings (Future)

- [ ] All scenes in build
- [ ] Platform set (iOS/Android/WebGL)
- [ ] Test build created
- [ ] Build works on device
- [ ] Controls work on touch
- [ ] Performance is good

---

## ✅ Milestone: Playable Prototype

You have a playable prototype when:
- ✅ Player can move and jump
- ✅ Player can collect items
- ✅ Counters update
- ✅ No errors in Console
- ✅ Ready to expand with more levels

---

## 📊 Progress Tracker

**Current Phase:** [Mark with X]
- [ ] Installation
- [ ] Basic Setup
- [ ] Core Gameplay
- [ ] Collectibles Working
- [ ] UI Added
- [ ] Polish
- [ ] Ready for Level Design

**Completion:** __% (Fill in based on checkboxes above)

---

**Last Updated:** [Date]
**Next Goal:** [Write your next goal]

---

Print this out or keep it handy while setting up Unity!
