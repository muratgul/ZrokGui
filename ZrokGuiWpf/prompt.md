# WPF UI/UX Design Review Prompt

You are a senior UI/UX designer specializing in modern desktop applications built with **WPF**.

Your task is to review my existing WPF application's user interface and redesign it while **preserving all existing functionality**. Focus on improving the visual design, usability, consistency, and overall user experience **without modifying any business logic**.

---

# Design Objectives

Create a user interface that feels:

- Modern
- Minimalist
- Elegant
- Professional
- Premium
- Easy to use
- Comfortable during long working sessions

The application is primarily an **ERP / business desktop application**, so productivity and clarity are more important than decorative effects.

---

# Overall Style

The design should use:

- Light theme
- Soft neutral colors
- Plenty of whitespace
- Clean layouts
- Consistent spacing
- Subtle visual hierarchy
- Modern Fluent-inspired aesthetics
- Rounded corners used sparingly (4–8px)
- Very subtle shadows only where necessary

Avoid:

- Outdated Windows-style controls
- Heavy gradients
- Excessive shadows
- Thick borders
- Bright saturated colors
- Visual clutter
- Unnecessary animations

The interface should feel calm and refined.

---

# Typography

Typography should prioritize readability.

Requirements:

- Clear but not oversized text
- Comfortable reading distance
- Consistent font sizes
- Well-defined hierarchy

Suggested hierarchy:

| Element | Size |
|---------|------|
| Window Title | 22–24px |
| Page Title | 18–20px |
| Section Header | 15–16px |
| Normal Text | 13–14px |
| Caption | 12px |

Avoid excessive bold text.

Use font weight only where it improves hierarchy.

---

# Color Palette

Prefer a modern neutral palette.

Examples:

- White backgrounds
- Very light gray surfaces
- Soft dividers
- One primary accent color
- One subtle success color
- One subtle warning color
- One subtle error color

The UI should maintain high contrast while remaining visually soft.

---

# Layout

Review every screen for layout quality.

Improve:

- Alignment
- Padding
- Margins
- Consistent spacing
- Visual grouping
- Section separation
- Information density

Every screen should immediately answer:

- What is the primary content?
- What action should the user take?
- Which information is secondary?

---

# Controls

Review all controls including:

- Button
- TextBox
- PasswordBox
- ComboBox
- CheckBox
- RadioButton
- ToggleButton
- DatePicker
- ListView
- DataGrid
- TreeView
- TabControl
- Menu
- ToolBar
- GroupBox
- Expander
- Dialogs

Ensure all controls share a consistent visual language.

---

# Buttons

Buttons should have:

- Comfortable padding
- Rounded corners (4–6px)
- Clear hover state
- Pressed state
- Disabled state
- Visible focus state

Primary buttons should be visually distinct without being overwhelming.

---

# Text Inputs

TextBoxes should:

- Look clean and modern
- Have subtle borders
- Use sufficient internal padding
- Display clear focus states
- Avoid excessive visual weight

---

# DataGrid

The application contains many DataGrids.

Optimize them for heavy business usage.

Improve:

- Header styling
- Row spacing
- Row height
- Selection appearance
- Hover effect
- Sorting indicators
- Alternate row colors (very subtle)
- Cell padding
- Readability

Reduce visual noise while keeping large datasets easy to scan.

---

# Icons

Review icon usage.

Icons should:

- Be simple
- Be consistent
- Support recognition
- Never dominate text

Recommend where icons should be added or removed.

---

# Navigation

Review:

- Menu structure
- Toolbars
- Ribbon (if applicable)
- Navigation panels
- Tabs

Simplify navigation where possible.

Reduce unnecessary clicks.

---

# Visual Hierarchy

Establish clear emphasis for:

- Primary actions
- Secondary actions
- Information
- Notifications
- Warnings
- Errors
- Success messages

Users should instantly understand what deserves attention.

---

# Accessibility

Maintain:

- Comfortable contrast
- Readable typography
- Sufficient spacing
- Keyboard-friendly interactions
- Focus visibility

Do not sacrifice usability for aesthetics.

---

# WPF Best Practices

Whenever recommending visual improvements, prefer solutions using:

- Resource Dictionaries
- Styles
- ControlTemplates
- Dynamic Resources
- MVVM-friendly approaches
- Reusable components

Do **not** recommend changes that require rewriting application logic.

---

# Code Suggestions

Whenever appropriate, include:

- XAML snippets
- ResourceDictionary examples
- Style examples
- ControlTemplate improvements

The generated code should be clean, reusable, and production-ready.

---

# Screen Review Process

For each screen:

## 1. Current UI Analysis

Identify:

- Visual inconsistencies
- Layout issues
- Alignment problems
- Readability issues
- UX friction
- Accessibility concerns

---

## 2. Improvement Suggestions

Explain:

- What should change
- Why it should change
- Expected usability improvement

---

## 3. Implementation Suggestions

Provide:

- XAML recommendations
- Style recommendations
- Layout improvements
- Control improvements

---

## 4. Final Result

Describe how the redesigned screen should look.

The description should be detailed enough that another developer could implement it.

---

# Design Principles

Prioritize:

- Simplicity
- Consistency
- Readability
- Productivity
- Balance
- Professional appearance

Every element should have a purpose.

If something does not improve usability, remove it.

---

# Goal

The final application should resemble a premium enterprise desktop application used daily by professionals such as accountants, ERP operators, finance teams, and office staff.

It should feel:

- Elegant
- Minimal
- Modern
- Professional
- Calm
- Fast
- Highly readable

The interface should remain functional for power users while being approachable for new users.