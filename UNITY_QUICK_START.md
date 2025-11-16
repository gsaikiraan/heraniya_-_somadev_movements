# 🎮 Unity Setup - Step by Step

**Complete guide to get your Unity project running in 30 minutes!**

---

## ✅ Prerequisites

Before starting, make sure you have:
- [ ] **Unity Hub** installed
- [ ] **Unity Editor** 2021.3 LTS or newer
- [ ] **Visual Studio Code** or Visual Studio (for C# editing)
- [ ] This repository cloned to your computer

---

## 📥 Step 1: Install Unity (15 minutes)

### 1.1 Download Unity Hub
1. Go to https://unity.com/download
2. Click **"Download Unity Hub"**
3. Install Unity Hub on your system

### 1.2 Install Unity Editor
1. Open Unity Hub
2. Click **"Installs"** in the left sidebar
3. Click **"Install Editor"**
4. Select **"Unity 2021.3 LTS"** (or newer LTS version)
5. Click **"Next"**

### 1.3 Add Modules (IMPORTANT!)
Make sure these modules are selected:
- ✅ **2D Development** (includes Sprite tools)
- ✅ **iOS Build Support** (if targeting iPhone/iPad)
- ✅ **Android Build Support** (if targeting Android)
- ✅ **WebGL Build Support** (if targeting web)
- ✅ **Visual Studio Code Editor** (or Visual Studio)

Click **"Install"** and wait (10-15 min)

---

## 🆕 Step 2: Create Unity Project (5 minutes)

### 2.1 Open Unity Hub
1. Open Unity Hub
2. Click **"Projects"** in the left sidebar
3. Click **"New Project"**

### 2.2 Configure Project
**Template:** Select **"2D (Core)"**

**Project Name:** `HeraniyaJourney`

**Location:**
```
[Your path]/heraniya_-_somadev_movements/
```
⚠️ **IMPORTANT:** Point to THIS repository folder!

**Unity Version:** Select the version you just installed (2021.3 LTS)

Click **"Create Project"**

Unity will open (takes 2-3 minutes first time)

---

## ⚙️ Step 3: Configure Project Settings (5 minutes)

### 3.1 Player Settings

1. Go to **`Edit > Project Settings`**
2. Click **"Player"** in the left sidebar

**Company Name:** Your name or studio
**Product Name:** `Heraniya's Journey`

**Default Icon:** (We'll add later)

**Bundle Identifier:**
- iOS: `com.yourname.heraniyajourney`
- Android: `com.yourname.heraniyajourney`

### 3.2 Quality Settings

1. In Project Settings, click **"Quality"**
2. Set **Default Quality Level** to **"Medium"**
3. This balances visuals and mobile performance

### 3.3 Physics 2D Settings

1. In Project Settings, click **"Physics 2D"**
2. No changes needed, but note the default gravity is -9.81

### 3.4 Tags and Layers

1. In Project Settings, click **"Tags and Layers"**
2. Add these **Layers:**
   - Layer 6: `Ground`
   - Layer 7: `Player`
   - Layer 8: `Collectibles`
   - Layer 9: `Vehicles`
   - Layer 10: `Obstacles`

3. Add these **Tags:**
   - `Player`
   - `Collectible`
   - `Vehicle`

---

## 📁 Step 4: Organize Project Structure (2 minutes)

Your Unity project should now be at:
```
heraniya_-_somadev_movements/
├── Assets/               ← Unity creates this
│   ├── Scenes/
│   ├── Scripts/          ← We already have this!
│   ├── Sprites/
│   ├── Audio/
│   ├── Prefabs/
│   └── Materials/
├── Packages/             ← Unity creates this
├── ProjectSettings/      ← Unity creates this
└── [our existing files]
```

The scripts we wrote earlier are already in `Assets/Scripts/` - Unity will auto-import them!

### Verify Scripts Imported

1. In Unity, look at the **Project** window (bottom)
2. Navigate to `Assets > Scripts > Core`
3. You should see:
   - `GameManager.cs`
   - `GameSettings.cs`
   - `InputHandler.cs`
   - `AudioManager.cs`
   - `SaveSystem.cs`

4. Navigate to `Assets > Scripts > Gameplay`
5. You should see:
   - `PlayerController.cs`
   - `CollectionSystem.cs`
   - `Collectible.cs`
   - `VehicleController.cs`

✅ If you see all these, you're good to go!

⚠️ If you see errors in the Console, that's normal - we haven't created the scene yet!

---

## 🎬 Step 5: Create Test Scene (10 minutes)

### 5.1 Create Scene

1. **`File > New Scene`**
2. Choose **"2D (Core)"** template
3. **`File > Save As...`**
4. Save to: `Assets/Scenes/TestScene.unity`

### 5.2 Add to Build Settings

1. **`File > Build Settings`**
2. Click **"Add Open Scenes"**
3. TestScene should appear in the list
4. Close Build Settings

---

## 🎮 Step 6: Create Game Manager (5 minutes)

### 6.1 Create GameObject

1. In **Hierarchy** window, right-click
2. **`Create Empty`**
3. Rename to: `GameManager`
4. Position: (0, 0, 0)

### 6.2 Add Scripts

Select `GameManager` in Hierarchy, then in Inspector:
1. Click **"Add Component"**
2. Search for **"Game Manager"**
3. Click to add it

Repeat for these components:
- **Input Handler**
- **Audio Manager**
- **Collection System**

Your GameManager should now have 4 scripts attached!

---

## 👤 Step 7: Create Player Character (10 minutes)

### 7.1 Create Player GameObject

1. Right-click in Hierarchy
2. **`Create Empty`**
3. Rename to: `Heraniya`
4. Position: (0, 0, 0)

### 7.2 Add Sprite Renderer

1. Select `Heraniya`
2. **"Add Component"** > **"Sprite Renderer"**
3. Click the **Sprite** dropdown
4. Select **"Square"** (built-in Unity sprite)
5. Change **Color** to pink: `#FFB6C1`
6. Set **Order in Layer** to: `10`

### 7.3 Add Rigidbody2D

1. **"Add Component"** > **"Rigidbody 2D"**

Configure:
- **Body Type:** Dynamic
- **Mass:** 1
- **Linear Drag:** 0
- **Angular Drag:** 0.05
- **Gravity Scale:** 3
- **Collision Detection:** Continuous
- **Constraints:** Check **"Freeze Rotation Z"** ✅

### 7.4 Add Box Collider 2D

1. **"Add Component"** > **"Box Collider 2D"**
2. Click **"Edit Collider"** button
3. Adjust size to fit the sprite (should be close already)

### 7.5 Add Player Controller Script

1. **"Add Component"** > **"Player Controller"**

You'll see errors in red - that's because we need to set up references:

**Ground Layer:** Select **"Ground"** (we created this layer earlier)

### 7.6 Create Ground Check

1. Right-click `Heraniya` in Hierarchy
2. **`Create Empty`**
3. Rename to: `GroundCheck`
4. Position: (0, **-0.6**, 0) - slightly below player's feet

Now select `Heraniya` again:
- Drag `GroundCheck` to the **"Ground Check"** field in Player Controller

### 7.7 Set Player Tag

1. Select `Heraniya`
2. At top of Inspector, click **"Tag"** dropdown
3. Select **"Player"**
4. Click **"Layer"** dropdown
5. Select **"Player"**

---

## 🟩 Step 8: Create Ground (5 minutes)

### 8.1 Create Ground GameObject

1. Right-click in Hierarchy
2. **`2D Object > Sprite > Square`**
3. Rename to: `Ground`
4. Position: (0, **-3**, 0)

### 8.2 Configure Ground

**Transform:**
- Scale: X=**20**, Y=**1**, Z=1

**Sprite Renderer:**
- Color: Brown `#8B4513`
- Order in Layer: 0

**Add Components:**
1. **"Add Component"** > **"Box Collider 2D"**
2. (Collider should auto-fit the sprite)

**Set Layer:**
- Tag: **Untagged**
- Layer: **Ground**

---

## 🎯 Step 9: First Test! (2 minutes)

### 9.1 Position Camera

1. Select **"Main Camera"** in Hierarchy
2. Set Position: (0, 0, **-10**)
3. Set Size: **6** (zoom out a bit)

### 9.2 Run the Game!

1. Make sure **Heraniya** and **Ground** are visible in Scene view
2. Click the **Play** button ▶️ at the top

**What should happen:**
- ✅ Heraniya falls and lands on ground
- ✅ She doesn't rotate (frozen rotation)
- ✅ She stays in place (waiting for input)

**Try this:**
- Press **SPACE** → Heraniya should jump!
- Click anywhere in Game view → She should jump!

**🎉 If she jumps, YOU DID IT!** Your game is working!

### 9.3 Stop the Game

Click **Play** button again to stop ⏸️

---

## ⭐ Step 10: Create Collectible (10 minutes)

### 10.1 Create Star

1. Right-click in Hierarchy
2. **`2D Object > Sprite > Circle`**
3. Rename to: `Star`
4. Position: (3, 0, 0) - to the right of player

### 10.2 Configure Star

**Transform:**
- Scale: (0.5, 0.5, 1)

**Sprite Renderer:**
- Color: Yellow `#FFD700`
- Order in Layer: 5

**Add Components:**
1. **"Add Component"** > **"Circle Collider 2D"**
   - Check **"Is Trigger"** ✅
   - Radius: 0.5

2. **"Add Component"** > **"Collectible"** (our script!)

**Configure Collectible Script:**
- Type: **Star**
- Value: 1
- Auto Collect Radius: 1.0

### 10.3 Test Collection

1. Click **Play** ▶️
2. Press **SPACE** to jump
3. Try to land on the star

**What should happen:**
- Star disappears when you touch it
- Console shows: "Collected Star! Total: 1"

🎉 **If it collects, perfect!**

### 10.4 Create Prefab

Now save Star as a reusable prefab:

1. Create folder: `Assets/Prefabs/Collectibles`
2. Drag **Star** from Hierarchy to this folder
3. Star should turn blue (it's now a prefab!)
4. You can delete Star from scene (we'll place them later)

---

## 📝 Step 11: Add UI (Optional - 5 minutes)

### 11.1 Create Canvas

1. Right-click Hierarchy
2. **`UI > Canvas`**

Unity creates Canvas + EventSystem automatically

**Configure Canvas:**
- Render Mode: **Screen Space - Overlay**
- UI Scale Mode: **Scale With Screen Size**
- Reference Resolution: 1920 x 1080

### 11.2 Add Star Counter

1. Right-click **Canvas**
2. **`UI > Text - TextMeshPro`**
3. Click **"Import TMP Essentials"** if prompted
4. Rename to: `StarCounter`

**Position:**
- Anchor: Top-Left
- Pos X: 100, Pos Y: -50

**Text:**
- Text: "⭐ 0"
- Font Size: 36
- Color: White
- Alignment: Left

---

## ✅ CHECKPOINT: What You Should Have Now

Your scene should contain:
- ✅ **GameManager** (with 4 scripts)
- ✅ **Heraniya** (player, with GroundCheck child)
- ✅ **Ground** (brown platform)
- ✅ **Main Camera**
- ✅ **Canvas** (optional, for UI)

**Save your scene:** `Ctrl/Cmd + S`

---

## 🎮 Step 12: Test Complete Gameplay Loop

### 12.1 Place Multiple Stars

1. Drag **Star** prefab from `Prefabs/Collectibles` into scene
2. Position at: (3, 0, 0)
3. Duplicate (Ctrl+D) and position at: (5, 1, 0)
4. Duplicate again and position at: (7, -0.5, 0)

### 12.2 Play Test

1. Click **Play** ▶️
2. Use SPACE or click to jump
3. Try to collect all stars
4. Check Console for collection messages

---

## 🚀 Next Steps

### Immediate
- [ ] Create more collectibles (Cookie, Heart)
- [ ] Add vehicle prefab (Toy Car)
- [ ] Create longer ground platform
- [ ] Add background sprite
- [ ] Test camera following

### Short Term
- [ ] Build Level 1 layout
- [ ] Add placeholder sprites for Heraniya
- [ ] Create simple animations
- [ ] Add audio clips
- [ ] Build to mobile device

---

## 🐛 Troubleshooting

### "Scripts are missing!"
**Fix:** Make sure project is in the repository folder where `Assets/Scripts/` exists

### "Player falls through ground!"
**Fix:**
- Check Ground has Box Collider 2D
- Check Ground layer is set to "Ground"
- Check Player Controller's "Ground Layer" includes "Ground"

### "Jump doesn't work!"
**Fix:**
- Check InputHandler is in scene
- Check Player Controller references GroundCheck
- Check GroundCheck is positioned below player feet

### "Can't collect stars!"
**Fix:**
- Check Star has Circle Collider 2D with "Is Trigger" checked
- Check Player has tag "Player"
- Check Collectible script is attached to Star

### "I see errors in Console!"
**Fix:** Most common errors:
- Missing references: Assign them in Inspector
- Can't find AudioManager: Make sure it's in scene
- NullReferenceException: Check all script references are set

---

## 📞 Need More Help?

See these guides:
- `Assets/UNITY_SETUP.md` - More detailed info
- `QUICK_START.md` - General overview
- Unity Documentation: https://docs.unity3d.com/

---

## 🎉 Congratulations!

If you've made it this far, you have:
- ✅ Unity project set up
- ✅ Player character that can jump
- ✅ Collectibles that work
- ✅ All core scripts imported
- ✅ Ready to build the full game!

**Now go make something amazing for Heraniya! 🎮💕**
