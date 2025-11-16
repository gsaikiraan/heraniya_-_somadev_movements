# 🎮 Web Prototype - Heraniya's Journey

**A playable browser-based prototype to test core game mechanics!**

---

## 🚀 How to Play

### Method 1: Open Directly (Easiest!)

1. Simply **double-click** `index.html`
2. It will open in your default browser
3. Start playing immediately!

### Method 2: Local Server (Recommended for Testing)

```bash
# Navigate to prototype folder
cd prototype

# Python 3
python -m http.server 8000

# Python 2
python -m SimpleHTTPServer 8000

# Then open: http://localhost:8000
```

### Method 3: Live Server (VS Code)

1. Install "Live Server" extension in VS Code
2. Right-click `index.html`
3. Select "Open with Live Server"

---

## 🎯 Controls

### Desktop
- **SPACE** or **CLICK ANYWHERE** = Jump
- **SPACE/CLICK AGAIN** in air = Double Jump

### Mobile/Tablet
- **TAP ANYWHERE** = Jump
- **TAP AGAIN** in air = Double Jump

**That's it! Perfect for toddlers!** 👶

---

## ✨ Features Implemented

### Core Mechanics
- ✅ **Auto-walk** - Character moves right automatically
- ✅ **Tap-to-jump** - One-tap control (tap anywhere!)
- ✅ **Double jump** - Tap again while in air
- ✅ **Forgiving controls** - Coyote time for easier jumping

### Collectibles
- ⭐ **Stars** - Yellow sparkles (10 points each)
- 🍪 **Cookies** - Brown treats (20 points each)
- 💕 **Hearts** - Pink love (30 points each)

### Visual Effects
- ✨ Particle effects on collection
- 🌊 Floating animation on collectibles
- ☁️ Parallax scrolling clouds
- 🌞 Bright, cheerful sun
- 💚 Grassy ground with details

### UI Elements
- 📊 Live collection counters (top-left)
- 📏 Distance tracker (top-right)
- 💡 Clear instructions (bottom)
- 💕 Game title (center)

---

## 🎨 What You'll See

```
┌─────────────────────────────────────────┐
│ ⭐ 5  🍪 2  💕 3       Distance: 425m   │ ← Counters
│                                         │
│        💕 Heraniya's Journey 💕        │ ← Title
│   ☁️        ☁️         ☁️              │
│              🌞                         │ ← Sky
│                                         │
│        ⭐      🍪        💕            │ ← Collectibles
│                                         │
│      [Heraniya]                        │ ← Player
│  ═══════════════════════════════════   │ ← Ground
│                                         │
│     👆 TAP ANYWHERE TO JUMP! 🦘        │ ← Instructions
└─────────────────────────────────────────┘
```

---

## 🧪 Testing Guide

### What to Test

#### ✅ Core Mechanics
- [ ] Player auto-walks to the right
- [ ] Tap/click makes player jump
- [ ] Can jump again in air (double jump)
- [ ] Player lands smoothly
- [ ] Camera follows player

#### ✅ Collectibles
- [ ] Stars appear and float gently
- [ ] Can collect stars by touching them
- [ ] Counter updates when collected
- [ ] Particle effects appear
- [ ] New collectibles spawn automatically

#### ✅ Controls (Toddler-Friendly)
- [ ] Can tap ANYWHERE on screen (not just player)
- [ ] Touch response is immediate
- [ ] No complex gestures needed
- [ ] Forgiving jump timing

#### ✅ Mobile Testing
- [ ] Works on iPhone/iPad
- [ ] Works on Android phone/tablet
- [ ] Touch controls responsive
- [ ] No accidental zooming
- [ ] Fits screen properly

### Age Group Testing (Most Important!)

**Try with Heraniya (1 year 9 months):**

- [ ] Can she trigger jumps by tapping?
- [ ] Does she smile when collecting items?
- [ ] Are the colors appealing?
- [ ] Is it too fast or too slow?
- [ ] Does she want to play again?

**Observe:**
- Engagement level (eyes on screen?)
- Frustration points (missing jumps?)
- Delight moments (collecting, particles?)
- Attention span (how long playing?)

---

## 🔧 Technical Details

### Built With
- **HTML5 Canvas** - Graphics rendering
- **Vanilla JavaScript** - Game logic
- **CSS3** - UI styling

### Performance
- **60 FPS** target frame rate
- **Responsive** - Adapts to screen size
- **Lightweight** - Single file, <500 lines
- **No dependencies** - Works offline

### Browser Support
- ✅ Chrome 90+
- ✅ Firefox 88+
- ✅ Safari 14+
- ✅ Edge 90+
- ✅ Mobile Safari (iOS 13+)
- ✅ Chrome Mobile (Android 8+)

---

## 🎯 What We're Validating

### Design Questions
1. **Is tap-to-jump intuitive for toddlers?**
2. **Is auto-walk the right speed?** (Currently 3 units/frame)
3. **Are collectibles visible enough?**
4. **Is double jump needed or confusing?**
5. **Are the colors appealing to target age?**

### Technical Questions
1. **Do touch controls feel responsive?**
2. **Is the physics too realistic or cartoonish?**
3. **Should collectibles auto-collect or require touch?**
4. **Is the camera movement smooth?**

---

## 📝 Feedback Template

After testing, note down:

```
TESTER: [Name, Age]
DEVICE: [iPhone, Android, Desktop, etc.]
DURATION: [How long they played]

POSITIVES:
- [What worked well?]
- [What did they enjoy?]

ISSUES:
- [What was frustrating?]
- [What didn't work?]

SUGGESTIONS:
- [What would improve it?]
- [What's missing?]

OVERALL: [1-5 stars]
```

---

## 🚀 Next Steps After Testing

Based on prototype feedback:

1. **Adjust speeds** (walk, jump, fall)
2. **Tune collectible placement**
3. **Refine controls** (jump height, coyote time)
4. **Validate art style** (shapes vs. sprites)
5. **Plan audio** (what sounds to add?)

Then move to **Unity** with confidence!

---

## 🐛 Known Limitations

This is a **proof-of-concept prototype**, not the final game:

- ⚠️ Placeholder graphics (shapes, not final art)
- ⚠️ No audio yet
- ⚠️ Infinite scrolling only (no levels)
- ⚠️ No vehicles implemented
- ⚠️ No Somdev/ending
- ⚠️ Simple physics (not final)

**That's okay!** This is for **validating core feel**, not final polish.

---

## 💡 Tips for Best Results

### For Desktop Testing
- Use **fullscreen mode** (F11) for immersion
- Test with **mouse clicks** and **spacebar**
- Open browser console for debug info (F12)

### For Mobile Testing
- Test in **portrait and landscape**
- Try on **different screen sizes**
- Check **touch responsiveness**
- Ensure **no accidental zoom/scroll**

### For Toddler Testing
- **Sit with them** and observe
- **Don't guide too much** - see what's natural
- **Note their reactions** - smiles, frustration, etc.
- **Try multiple sessions** (fresh vs. tired)

---

## 📊 Metrics to Track

While testing, observe:

| Metric | Good | Needs Work |
|--------|------|------------|
| **Jump Success Rate** | >80% | <80% |
| **Collection Rate** | Most items | Missing many |
| **Engagement** | Focused | Distracted |
| **Session Length** | 2+ min | <1 min |
| **Repeat Plays** | Asks again | One and done |

---

## 🎉 Have Fun!

This prototype took ~30 minutes to build but represents **hours of game design thinking**.

**Most important**: Does it feel fun? Does it spark joy? Would Heraniya love it?

If yes → We're on the right track! 🎮💕

---

**Questions? Issues? Want to suggest changes?**

Document them and we'll iterate! This is just the beginning! 🚀
