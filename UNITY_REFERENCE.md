# 🎮 Unity Quick Reference

Essential shortcuts and tips for Unity development.

---

## ⌨️ Keyboard Shortcuts

### Essential
| Shortcut | Action |
|----------|--------|
| **Ctrl/Cmd + S** | Save scene |
| **Ctrl/Cmd + P** | Play/Pause game |
| **Ctrl/Cmd + Shift + P** | Pause (while playing) |
| **Ctrl/Cmd + D** | Duplicate selected object |
| **Ctrl/Cmd + Z** | Undo |
| **Ctrl/Cmd + Y** | Redo |
| **Delete/Backspace** | Delete selected object |

### Navigation
| Shortcut | Action |
|----------|--------|
| **F** | Frame selected object |
| **Alt + Left Mouse** | Rotate view |
| **Middle Mouse** | Pan view |
| **Scroll Wheel** | Zoom |
| **Right Mouse + WASD** | Fly around scene |

### Windows
| Shortcut | Action |
|----------|--------|
| **Ctrl/Cmd + 1** | Scene view |
| **Ctrl/Cmd + 2** | Game view |
| **Ctrl/Cmd + 3** | Inspector |
| **Ctrl/Cmd + 4** | Hierarchy |
| **Ctrl/Cmd + 5** | Project |
| **Ctrl/Cmd + 6** | Animation |
| **Ctrl/Cmd + 7** | Profiler |
| **Ctrl/Cmd + 9** | Asset Store |

### Useful
| Shortcut | Action |
|----------|--------|
| **Ctrl/Cmd + N** | New scene |
| **Ctrl/Cmd + O** | Open scene |
| **Ctrl/Cmd + B** | Build settings |
| **V** | Vertex snap (hold while moving) |
| **Q** | Pan tool |
| **W** | Move tool |
| **E** | Rotate tool |
| **R** | Scale tool |
| **T** | Rect tool (UI) |

---

## 🎨 Common Tasks

### Creating Objects

**Empty GameObject:**
- Hierarchy → Right-click → Create Empty

**2D Sprite:**
- Hierarchy → Right-click → 2D Object → Sprites → [Shape]

**UI Elements:**
- Hierarchy → Right-click → UI → [Element]

**Prefab Instance:**
- Drag prefab from Project to Hierarchy or Scene

### Working with Components

**Add Component:**
1. Select GameObject
2. Inspector → Add Component
3. Search for component name

**Remove Component:**
- Right-click component header → Remove Component

**Copy Component:**
- Right-click component header → Copy Component

**Paste Component:**
- Right-click in Inspector → Paste Component As New

### Prefabs

**Create Prefab:**
- Drag GameObject from Hierarchy to Project window

**Apply Changes to Prefab:**
- Select prefab instance → Inspector → Overrides → Apply All

**Revert to Prefab:**
- Select prefab instance → Inspector → Overrides → Revert All

**Edit Prefab:**
- Double-click prefab in Project window

---

## 🔧 Inspector Tips

### Transform Component
- **Position:** Where object is in world
- **Rotation:** Object's orientation
- **Scale:** Object's size

**Reset Transform:**
- Right-click Transform → Reset

**Copy Transform:**
- Right-click Transform → Copy Component
- Select other object → Paste Component Values

### Sprite Renderer
- **Sprite:** The image to display
- **Color:** Tint the sprite
- **Flip:** Mirror horizontally/vertically
- **Order in Layer:** Higher = in front

### Rigidbody2D
- **Dynamic:** Affected by physics
- **Kinematic:** Move with code, not physics
- **Static:** Doesn't move at all

- **Mass:** How heavy
- **Gravity Scale:** How fast it falls (1 = normal)
- **Freeze Rotation:** Prevent spinning

### Collider2D
- **Is Trigger:** Pass through, but detect collision
- **Not Trigger:** Solid, blocks movement

**Trigger = Collectibles**
**Not Trigger = Walls/Ground**

---

## 🎮 Scene View Controls

### 2D Mode
- Click **2D** button in Scene toolbar
- Camera looks at XY plane
- Perfect for 2D games!

### Gizmos
- Toggle icons/gizmos in Scene view
- Useful to hide/show debug visualizations

### Grid Snapping
- Hold **Ctrl/Cmd** while moving objects
- Snaps to grid for precise placement

---

## 🐛 Debugging

### Console Window
- **Clear:** Remove all messages
- **Collapse:** Group similar messages
- **Clear on Play:** Auto-clear when playing

**Message Types:**
- 🟦 Blue = Info (Debug.Log)
- ⚠️ Yellow = Warning
- 🔴 Red = Error

### Debug.Log()
```csharp
Debug.Log("Hello World");
Debug.Log($"Score: {score}");
Debug.LogWarning("Watch out!");
Debug.LogError("Something broke!");
```

### Pause on Error
- Console → Click pause button icon
- Game pauses when error occurs
- Easier to debug!

---

## 📁 Project Organization

### Folder Structure
```
Assets/
├── Scenes/         (All scene files)
├── Scripts/        (All C# scripts)
│   ├── Core/
│   └── Gameplay/
├── Sprites/        (All images)
├── Audio/          (Music and SFX)
├── Prefabs/        (Reusable objects)
├── Materials/      (Visual properties)
└── Animations/     (Animation files)
```

### Naming Conventions
- **PascalCase** for classes/files: `PlayerController.cs`
- **camelCase** for variables: `jumpForce`
- **Descriptive names:** `groundCheckRadius` not `gcr`

---

## 🎬 Play Mode

### While Playing

**Changes made in Play Mode are TEMPORARY!**

⚠️ **WARNING:** When you stop playing, changes are lost!

**Good practice:**
1. Stop playing
2. Make changes
3. Test changes

**Or:**
1. Make changes while playing
2. Copy component values
3. Stop playing
4. Paste values back

---

## 🔨 Build & Run

### Quick Build (Testing)
1. File → Build Settings
2. Select platform
3. Build And Run

### Proper Build (Distribution)
1. File → Build Settings
2. Check all scenes included
3. Player Settings → Configure:
   - Company Name
   - Product Name
   - Icons
   - Bundle Identifier
4. Build

---

## 💡 Pro Tips

### Performance
- Use **object pooling** for frequent spawns
- Limit **Update()** calls where possible
- Use **FixedUpdate()** for physics
- Profile with **Profiler** window (Ctrl/Cmd + 7)

### Organization
- **Name everything** clearly
- Use **folders** to organize
- Create **prefabs** for reusable objects
- Use **tags** and **layers** wisely

### Workflow
- **Save often** (Ctrl/Cmd + S)
- Use **version control** (Git)
- **Test frequently** - don't code for hours without testing
- Keep **Console clean** - fix warnings and errors

---

## 📱 Mobile Testing

### Unity Remote
- Download Unity Remote app on phone
- Connect phone via USB
- Enable in Editor → Edit → Project Settings → Editor
- See game on phone while playing in Editor!

### Build to Device
**iOS:**
1. Switch platform to iOS
2. Build → Generates Xcode project
3. Open in Xcode
4. Build to device from Xcode

**Android:**
1. Switch platform to Android
2. Build → Generates APK
3. Install APK on device
4. Run and test!

---

## 🆘 Common Problems

### "Script is missing!"
- Script was deleted or renamed
- Find GameObject with missing script
- Remove and re-add correct script

### "NullReferenceException"
- Trying to use something that doesn't exist
- Check all public variables are assigned in Inspector
- Use `if (thing != null)` to check first

### "Can't find method/component"
- Typo in name
- Wrong namespace
- Missing `using` statement at top of script

### "Game runs slow in Editor"
- Normal! Editor adds overhead
- Build to device for true performance
- Use Profiler to find bottlenecks

### "Changes not saving"
- Made changes while playing? (They won't save!)
- Forgot to save scene? (Ctrl/Cmd + S)
- Forgot to apply prefab changes?

---

## 📚 Learning Resources

### Official
- **Unity Learn:** https://learn.unity.com/
- **Unity Manual:** https://docs.unity3d.com/Manual/
- **Unity Scripting API:** https://docs.unity3d.com/ScriptReference/

### YouTube Channels
- **Brackeys** - Beginner-friendly tutorials
- **Code Monkey** - Clear explanations
- **Sebastian Lague** - Advanced topics

### Community
- **Unity Forums:** https://forum.unity.com/
- **Unity Discord:** Official server
- **r/Unity2D** - Reddit community

---

## 🎯 Quick Troubleshooting

**Problem → Solution**

| Problem | Solution |
|---------|----------|
| Player falls through ground | Check ground has collider, check layers |
| Jump doesn't work | Check Rigidbody2D is Dynamic, check input code |
| Can't collect items | Check colliders overlap, check "Is Trigger" |
| Camera doesn't follow | Add CinemachineVirtualCamera or custom script |
| Audio doesn't play | Check AudioSource, check clip assigned |
| Build fails | Check Console for errors, check Build Settings |
| Script errors | Read error message carefully, Google it! |

---

**Keep this handy while working in Unity!** 📌

**Most important tip:** Don't be afraid to experiment and break things. That's how you learn! 🚀
