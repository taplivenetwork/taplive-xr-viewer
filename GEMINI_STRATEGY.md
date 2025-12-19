# Gemini AI Integration Strategy

## Overview
This document outlines the strategy for integrating AI assistance (Gemini) into the development workflow of `taplive-xr`.

## 1. Context Awareness
- **Repository Structure**: AI agents should have read access to the root directory to understand the Unity project structure.
- **Key Files**: `README.md` and `task.md` serve as the primary context anchors for the AI.

## 2. Coding Standards for AI
- **Language**: C# (latest stable Unity supported version).
- **Style**: Standard C# conventions (PascalCase for methods/classes, camelCase for fields).
- **Unity Specifics**:
    - Use `SerializeField` for inspector variables instead of public fields where possible.
    - Prefer `Unity.Mathematics` or standard vector math.
    - Ensure XR Interaction Toolkit compatibility.

## 3. Future AI Features
- **Generative Code**: Using Gemini to prototype new interaction patterns.
- **Asset Generation**: Potential integration for generating placeholder UI textures or skyboxes.
- **Docs Auto-update**: AI responsible for keeping `README.md` in sync with code changes.

## 4. Operational Boundaries
- AI will not modify binary assets directly unless via a specialized tool.
- AI acts as a "Senior Developer" pair programmer, suggesting changes for review.
