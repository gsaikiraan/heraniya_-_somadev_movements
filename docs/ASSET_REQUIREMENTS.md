# 🎨 Asset Requirements
## Heraniya's Journey to See Somdev

---

## Character Assets

### Heraniya (Player Character)

#### Sprite Specifications
- **Base Size:** 128x128px
- **Format:** PNG (32-bit with alpha)
- **Color Depth:** 24-bit color + 8-bit alpha
- **Total Sprite Sheet:** 2048x2048px

#### Required Animations

| Animation | Frames | FPS | Duration | Notes |
|-----------|--------|-----|----------|-------|
| Idle | 4 | 2 | 2s loop | Gentle sway, blinking |
| Walk | 6 | 12 | 0.5s loop | Toddler waddle |
| Run | 6 | 18 | 0.33s loop | Faster waddle |
| Jump | 8 | 24 | 0.33s | Crouch → air → land |
| Double Jump | 8 | 24 | 0.33s | With 360° spin |
| Ride Vehicle | 4 | 8 | 0.5s loop | Sitting, bouncing |
| Tiptoe | 6 | 8 | 0.75s loop | Quiet walking |
| Collect Item | 3 | 10 | 0.3s | Reach and grab |
| Mount Vehicle | 6 | 12 | 0.5s | Approach → sit |
| Dismount Vehicle | 4 | 12 | 0.33s | Stand → hop off |
| Bump | 4 | 12 | 0.33s | Recoil, surprised |

#### Expression Variations
- Happy (default)
- Excited
- Surprised
- Quiet (shh!)
- Content
- Loving

#### Color Palette
```
Skin: #F4C2A0
Hair: #3D2817
Outfit Primary: #FFB6C1
Outfit Secondary: #DDA0DD
Eyes: #4A3C2F
Cheeks: #FFB6BA
Shoes: #FF69B4
```

---

### Baby Somdev

#### Sprite Specifications
- **Base Size:** 64x64px
- **Format:** PNG (32-bit)
- **Style:** Tiny, peaceful, sleeping

#### Required Animations

| Animation | Frames | FPS | Duration |
|-----------|--------|-----|----------|
| Sleeping | 2 | 0.66 | 3s loop |
| Breathing | 2 | 0.66 | 3s loop |
| Tiny Movement | 3 | 1 | 3s |

#### Color Palette
```
Skin: #FFE4C4
Outfit: #B0E0E6
Blanket: #FFFACD
```

---

### Pet (Dog/Cat)

#### Sprite Specifications
- **Base Size:** 96x96px
- **Format:** PNG (32-bit)

#### Required Animations

| Animation | Frames | FPS | Duration |
|-----------|--------|-----|----------|
| Walk | 4 | 12 | 0.33s loop |
| Run | 4 | 18 | 0.22s loop |
| Sit | 2 | 4 | 0.5s loop |
| Celebrate | 6 | 12 | 0.5s |

---

## Environment Assets

### Level 1: Living Room

#### Background Layers (Parallax)
1. **Far Wall** (1920x1080px)
   - Window with clouds
   - Wall color: #F5E6D3

2. **Mid Wall** (1920x1080px)
   - Family photos (5 frames)
   - Clock
   - Wall decorations

3. **Furniture** (various sizes)
   - Sofa: 512x256px
   - TV: 256x192px
   - Bookshelf: 192x384px
   - Toy box: 192x128px

#### Interactive Objects
- TV (256x192px) - 2 states: off, on
- Toy box (192x128px) - 2 states: closed, open
- Remote control (32x32px)
- Cushions (96x96px each) - various colors

#### Collectibles
- Stars ⭐: 48x48px
- Cookies 🍪: 48x48px
- Hearts 💕: 48x48px

---

### Level 2: Hallway

#### Background Layers
1. **Far Wall** (3000x1080px) - longer level
   - Doors (5 different doors)
   - Windows

2. **Mid Wall Decorations**
   - Family photos (10 frames) - 128x128px each
   - Light switches - 32x32px
   - Potted plants - 64x128px

#### Obstacles
- Shoes: 64x32px (multiple styles)
- Laundry basket: 128x128px
- Rolling toys: 48x48px
- Balloons: 64x128px

---

### Level 3: Bedroom

#### Background Layers
1. **Room Background** (1200x1080px)
   - Night sky window
   - Moon and stars
   - Lavender walls: #E6E6FA

#### Key Objects
- Crib: 256x192px (center focus)
- Baby mobile: 128x96px (hanging)
- Night lights: 32x32px (multiple)
- Soft toys: 48x48px (arranged around)

---

## Vehicle Assets

### Toy Car 🚗
- **Size:** 128x96px
- **States:** Idle, moving, honking
- **Frames:** 4 per animation
- **Color:** Red/pink (#FF69B4)
- **Effects:** Sparkle trail

### Scooter 🛴
- **Size:** 128x128px
- **States:** Idle, moving, bell ringing
- **Frames:** 4 per animation
- **Color:** Blue/purple (#DDA0DD)
- **Effects:** Streamers (fluttering)

---

## UI Assets

### Buttons

| Button Type | Size | States | Format |
|-------------|------|--------|--------|
| Primary (Play) | 400x120px | Normal, Pressed, Disabled | PNG |
| Secondary | 300x100px | Normal, Pressed | PNG |
| Icon Button | 80x80px | Normal, Pressed | PNG |
| Small Button | 200x80px | Normal, Pressed | PNG |

### Icons

| Icon | Size | Usage |
|------|------|-------|
| Star ⭐ | 64x64px | Collectible, counter |
| Cookie 🍪 | 64x64px | Collectible, counter |
| Heart 💕 | 64x64px | Collectible, counter |
| Pause ⏸️ | 64x64px | HUD |
| Sound 🔊 | 64x64px | HUD |
| Settings ⚙️ | 64x64px | Menu |
| Gallery 📸 | 64x64px | Menu |

### Photo Frames

| Frame | Size | Unlocked By |
|-------|------|-------------|
| Star Frame | 1080x1350px | 40+ stars |
| Heart Frame | 1080x1350px | All hearts |
| Cookie Frame | 1080x1350px | All cookies |
| Perfect Frame | 1080x1350px | 100% complete |

---

## Particle Effects

### Sparkles
- **Texture:** 16x16px white star
- **Count:** 20-50 particles
- **Lifespan:** 0.5-1s
- **Colors:** Gold (#FFD700), White, Pink

### Confetti
- **Textures:** Squares, circles, stars (8x8px each)
- **Count:** 50-100 particles
- **Lifespan:** 1-2s
- **Colors:** Rainbow variety

### Hearts
- **Texture:** 32x32px heart shape
- **Count:** 10-20 particles
- **Lifespan:** 2-3s
- **Color:** Pink gradient

---

## Audio Assets

### Music Tracks

| Track | Length | Tempo | Key | Format |
|-------|--------|-------|-----|--------|
| Main Menu Theme | 1:30 | 120 BPM | C Major | OGG 128kbps |
| Level 1 (Living Room) | 2:00 | 140 BPM | G Major | OGG 128kbps |
| Level 2 (Hallway) | 2:30 | 150 BPM | D Major | OGG 128kbps |
| Level 3 (Bedroom) | 1:30 | 60 BPM | F Major | OGG 128kbps |
| Ending Cutscene | 1:00 | 70 BPM | C→G Major | OGG 128kbps |
| Victory Screen | 0:30 | 130 BPM | C Major | OGG 128kbps |

### Sound Effects

#### Character Sounds (20 files)
- Jump: "Wheee!" x3 variations (WAV 16-bit)
- Double Jump: "Woohoo!" x2 (WAV)
- Collect Star: "Yay!" x5 (WAV)
- Collect Cookie: "Yummy!" x3 (WAV)
- Bump: "Oof!" x2 (WAV)
- Mount: "Let's go!" x1 (WAV)
- Quiet: "Shh!" x1 (WAV)
- Seeing Somdev: "Somdev!" x1 (WAV)
- Footsteps: Walking, running, tiptoe (WAV loops)

#### Collectible Sounds (10 files)
- Star chime x3 variations
- Cookie crunch x3 variations
- Heart glow x3 variations
- Sparkle whoosh x1

#### Vehicle Sounds (15 files)
- Car engine start, idle, driving, stop
- Car horn "Beep beep!"
- Scooter glide, push-off, stop
- Scooter bell "Ring ring!"
- Wheel rolling sounds

#### Object/Environment (30 files)
- Door open/close x5
- TV on/off/static
- Toy box open/creak
- Balloons pop x3
- Photo frame glow
- Clock ticking
- Ambient sounds (birds, gentle hum)

#### UI Sounds (15 files)
- Button tap x3
- Menu open/close
- Pause/resume
- Achievement unlock
- Victory fanfare
- Error sound

---

## File Organization

```
/Assets
  /Characters
    /Heraniya
      Heraniya_Idle.png
      Heraniya_Walk.png
      Heraniya_Jump.png
      Heraniya_Expressions.png
    /Somdev
      Somdev_Sleeping.png
    /Pet
      Pet_Animations.png

  /Environments
    /LivingRoom
      LR_Background_Far.png
      LR_Background_Mid.png
      LR_Furniture.png
      LR_Interactive.png
    /Hallway
      Hall_Background.png
      Hall_Objects.png
    /Bedroom
      Bedroom_Background.png
      Bedroom_Furniture.png

  /Vehicles
    ToyCar_Spritesheet.png
    Scooter_Spritesheet.png

  /UI
    /Buttons
      Button_Play_Normal.png
      Button_Play_Pressed.png
      [etc...]
    /Icons
      Icon_Star.png
      Icon_Cookie.png
      [etc...]
    /Frames
      Frame_Star.png
      Frame_Heart.png
      [etc...]

  /Effects
    /Particles
      Sparkle.png
      Confetti_Square.png
      Confetti_Circle.png
      Heart.png

  /Audio
    /Music
      MainMenu.ogg
      Level1_LivingRoom.ogg
      Level2_Hallway.ogg
      Level3_Bedroom.ogg
      Ending.ogg
    /SFX
      /Character
        Jump_01.wav
        Jump_02.wav
        [etc...]
      /Collectibles
        Star_Chime_01.wav
        [etc...]
      /Vehicles
        Car_Vroom.wav
        [etc...]
      /UI
        Button_Tap.wav
        [etc...]
```

---

## Asset Creation Guidelines

### Visual Style
- **Art Style:** Hand-drawn digital, cleaned up
- **Line Art:** 2-3px thick black outlines
- **Shading:** Cel-shaded (flat colors + simple shadows)
- **Colors:** Bright, saturated, cheerful
- **Shapes:** Rounded, soft (no sharp edges)

### Technical Requirements
- **Resolution:** Design at 2x target size, scale down
- **Color Mode:** RGB (not CMYK)
- **Transparency:** Use alpha channel where needed
- **Compression:** PNG for sprites, JPEG for opaque backgrounds
- **Naming:** Descriptive, lowercase, underscores (e.g., `heraniya_walk_01.png`)

### Audio Guidelines
- **Recording:** 44.1kHz, 16-bit minimum
- **Voice:** Child voice for Heraniya (1-2 years old sound)
- **Music:** Gentle instruments, no harsh sounds
- **SFX:** Clear, not too loud, pleasant
- **Normalization:** -6dB headroom for mixing

---

## Asset Production Schedule

### Week 1-2: Character Art
- [ ] Heraniya concept art
- [ ] Heraniya sprite animations
- [ ] Somdev sprite
- [ ] Pet sprites

### Week 3-4: Environment Art
- [ ] Living Room background layers
- [ ] Living Room objects
- [ ] Hallway assets
- [ ] Bedroom assets

### Week 5: Vehicles & Items
- [ ] Toy car sprites
- [ ] Scooter sprites
- [ ] Collectible icons
- [ ] Interactive objects

### Week 6: UI/UX Art
- [ ] Button designs
- [ ] Icon set
- [ ] Menu backgrounds
- [ ] Photo frames

### Week 7: Particle Effects
- [ ] Sparkle textures
- [ ] Confetti pieces
- [ ] Heart effects
- [ ] Speed lines

### Week 8-9: Audio Production
- [ ] Music composition (6 tracks)
- [ ] Voice recording (Heraniya)
- [ ] Sound effects (100 files)
- [ ] Audio mixing/mastering

---

## Asset Checklist

### Characters
- [ ] Heraniya - All animations (11 sets)
- [ ] Heraniya - All expressions (6 variations)
- [ ] Somdev - Sleeping animations
- [ ] Pet - All animations (4 sets)

### Environments
- [ ] Level 1 - Complete (Background + objects)
- [ ] Level 2 - Complete
- [ ] Level 3 - Complete

### Vehicles
- [ ] Toy Car - Complete (sprites + effects)
- [ ] Scooter - Complete

### UI
- [ ] All buttons (12 types)
- [ ] All icons (20+ icons)
- [ ] Photo frames (4 frames)
- [ ] Menus (5 screens)

### Audio
- [ ] Music tracks (6 complete)
- [ ] Character sounds (20 files)
- [ ] SFX (100 files)
- [ ] Ambient sounds (10 files)

### Effects
- [ ] Particle systems (4 types)
- [ ] Transitions (fade, slide, scale)
- [ ] Collection feedback effects

---

**Total Estimated Assets:** ~500 files
**Total Size (compressed):** ~120MB
**Production Time:** 8-10 weeks

---

**Last Updated:** 2025-11-16
