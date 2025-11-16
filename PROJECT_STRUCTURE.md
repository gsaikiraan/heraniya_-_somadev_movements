# 📁 Project Structure

```
heraniya_-_somadev_movements/
│
├── .git/                           # Git repository
├── .gitignore                      # Git ignore file
├── README.md                       # Project overview
├── PROJECT_STRUCTURE.md            # This file
│
├── docs/                           # Documentation
│   ├── GAME_DESIGN.md             # Complete game design document
│   ├── ROADMAP.md                 # Development roadmap and timeline
│   ├── TECHNICAL_SPEC.md          # Technical specifications
│   ├── ASSET_REQUIREMENTS.md      # Asset creation guidelines
│   └── MEETING_NOTES.md           # Development meeting notes
│
├── design/                         # Design files and references
│   ├── concept_art/               # Character and environment concepts
│   ├── wireframes/                # UI/UX wireframes
│   ├── color_palettes/            # Color scheme references
│   └── references/                # Visual references and inspiration
│
├── assets/                         # Game assets (not in version control)
│   ├── characters/                # Character sprites and animations
│   │   ├── heraniya/
│   │   ├── somdev/
│   │   └── pet/
│   ├── environments/              # Environment art
│   │   ├── living_room/
│   │   ├── hallway/
│   │   └── bedroom/
│   ├── vehicles/                  # Vehicle sprites
│   ├── ui/                        # UI elements
│   │   ├── buttons/
│   │   ├── icons/
│   │   ├── frames/
│   │   └── menus/
│   ├── effects/                   # Particle effects and VFX
│   ├── audio/                     # Audio files
│   │   ├── music/
│   │   └── sfx/
│   └── fonts/                     # Font files
│
├── src/                            # Source code (structure depends on engine choice)
│   ├── scripts/                   # Game scripts/code
│   │   ├── core/                  # Core systems
│   │   ├── gameplay/              # Gameplay mechanics
│   │   ├── ui/                    # UI controllers
│   │   └── utils/                 # Utility functions
│   ├── scenes/                    # Game scenes/levels
│   └── prefabs/                   # Reusable game objects
│
├── builds/                         # Build outputs (not in version control)
│   ├── ios/
│   ├── android/
│   └── web/
│
├── tests/                          # Test files
│   ├── unit/                      # Unit tests
│   └── integration/               # Integration tests
│
└── tools/                          # Development tools and scripts
    ├── build_scripts/             # Automated build scripts
    └── asset_pipeline/            # Asset processing tools
```

## Directory Descriptions

### `/docs`
Contains all project documentation including design documents, technical specifications, and development roadmap.

### `/design`
Source design files, concept art, and references used during the design phase.

### `/assets`
All game assets organized by type. This directory should be excluded from version control except for a README explaining the asset pipeline.

### `/src`
Source code for the game. Structure will vary based on chosen engine (Unity, Phaser, Godot).

### `/builds`
Compiled game builds for different platforms. Excluded from version control.

### `/tests`
Automated tests for game systems and mechanics.

### `/tools`
Custom tools and scripts to assist development (build automation, asset processing, etc.).

---

## Version Control Strategy

### Included in Git:
- All documentation (`.md` files)
- Source code
- Project configuration files
- Small reference images in docs

### Excluded from Git:
- Large asset files (use Git LFS or asset hosting)
- Build outputs
- Temporary files
- IDE-specific files
- Cache directories

---

## Next Steps

1. Choose game engine (Unity recommended)
2. Initialize engine project structure
3. Set up asset pipeline
4. Begin prototype development

---

**Last Updated:** 2025-11-16
