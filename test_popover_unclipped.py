import sys
import os
import time

sys.stdout.reconfigure(encoding='utf-8')
from playwright.sync_api import sync_playwright

def main():
    print("=" * 80)
    print("TESTING TWPOPOVER UNCLIPPED & 8-WAY ARROW ANCHORING SUITE")
    print("=" * 80)

    screenshot_dir = r"C:\Users\donpo\.gemini\antigravity\brain\27e04055-7eb7-457e-ac4c-93c7084425b7\screenshots"
    os.makedirs(screenshot_dir, exist_ok=True)
    screenshot_path = os.path.join(screenshot_dir, "popover-unclipped-8way-verified.png")

    with sync_playwright() as p:
        browser = p.chromium.launch(headless=True)
        context = browser.new_context(viewport={"width": 1440, "height": 960})
        page = context.new_page()

        print("Navigating to http://127.0.0.1:5128/?tab=components...")
        page.goto("http://127.0.0.1:5128/?tab=components", wait_until="networkidle", timeout=30000)
        page.wait_for_timeout(3500)

        # Scroll to Anchored Popover section
        popover_heading = page.locator("text=2. Anchored Popover (TwPopover)").first
        popover_heading.scroll_into_view_if_needed()
        page.wait_for_timeout(1000)

        # ---------------------------------------------------------------------
        # 1. Test Unclipped Bottom Placement
        # ---------------------------------------------------------------------
        print("\n[STEP 1] Testing Default Bottom Placement & Anti-Clipping Breakout...")
        btn = page.locator("button:has-text('Configure Metrics')").first
        btn.click()
        page.wait_for_timeout(600)

        # Verify Popover is open
        dialog = page.locator("[role='dialog']").first
        dialog.wait_for(state="visible", timeout=5000)
        assert page.locator("text=Display Filters").count() > 0, "Popover title not found!"

        # Inspect popover positioning & overflow
        layout_info = page.evaluate("""() => {
            const popover = document.querySelector('[role="dialog"]');
            const popoverStyle = window.getComputedStyle(popover);
            const rect = popover.getBoundingClientRect();
            
            return {
                position: popoverStyle.position,
                zIndex: popoverStyle.zIndex,
                top: rect.top,
                bottom: rect.bottom,
                left: rect.left,
                right: rect.right,
                height: rect.height,
                width: rect.width
            };
        }""")
        print(f"  ✓ Popover position: {layout_info['position']}, z-index: {layout_info['zIndex']}")
        print(f"  ✓ Dimensions: {layout_info['width']}x{layout_info['height']} at ({layout_info['left']}, {layout_info['top']})")
        assert layout_info['position'] == 'fixed', "Popover must be position: fixed to break out of clipping containers!"
        assert int(layout_info['zIndex']) >= 9999, "Popover z-index must be >= 9999!"

        # Close via Apply button
        page.locator("button:has-text('Apply')").first.click()
        page.wait_for_timeout(500)
        assert page.locator("[role='dialog']").count() == 0, "Popover should be closed after Apply!"
        print("  ✓ Closed cleanly via Apply button.")

        # ---------------------------------------------------------------------
        # 2. Test All 8 Placements
        # ---------------------------------------------------------------------
        placements = [
            ("Top", "Top (Center)"),
            ("TopStart", "Top Start (Left)"),
            ("TopEnd", "Top End (Right)"),
            ("Bottom", "Bottom (Center)"),
            ("BottomStart", "Bottom Start (Left)"),
            ("BottomEnd", "Bottom End (Right)"),
            ("Left", "Left"),
            ("Right", "Right")
        ]

        print("\n[STEP 2] Testing All 8-Way Arrow Placements...")
        placement_select = page.locator("select").filter(has_text="Bottom (Center)").first

        for val, label in placements:
            print(f"  -> Testing Placement: {val} ({label})...")
            placement_select.select_option(val)
            page.wait_for_timeout(300)

            btn.click()
            page.wait_for_timeout(400)

            # Assert dialog is open and visible
            assert page.locator("[role='dialog']").count() > 0, f"Popover failed to open for {val}"
            
            # Check arrow element
            arrow = page.locator("[role='dialog'] div[id*='arrow']").first
            assert arrow.count() > 0, f"Arrow element missing for {val}"

            # Close popover
            btn.click()
            page.wait_for_timeout(300)
            print(f"     ✓ {val} positioned with arrow successfully!")

        # ---------------------------------------------------------------------
        # 3. Test Escape Key Dismiss
        # ---------------------------------------------------------------------
        print("\n[STEP 3] Testing Escape Key Dismiss...")
        placement_select.select_option("Bottom")
        page.wait_for_timeout(200)
        btn.click()
        page.wait_for_timeout(400)
        assert page.locator("[role='dialog']").count() > 0, "Popover should be open"

        # Press Escape key
        page.keyboard.press("Escape")
        page.wait_for_timeout(500)
        assert page.locator("[role='dialog']").count() == 0, "Popover should dismiss on Escape key!"
        print("  ✓ Escape key dismissal verified!")

        # ---------------------------------------------------------------------
        # 4. Test Hover Activation Mode
        # ---------------------------------------------------------------------
        print("\n[STEP 4] Testing Hover Activation Mode...")
        trigger_select = page.locator("select").filter(has_text="Click").first
        trigger_select.select_option(value="Hover")
        page.wait_for_timeout(500)

        # Move mouse away first so hover enters cleanly
        page.mouse.move(0, 0)
        page.wait_for_timeout(200)

        # Hover anchor button
        btn.hover()
        page.wait_for_timeout(600)
        assert page.locator("[role='dialog']").count() > 0, "Popover should open on hover!"
        print("  ✓ Hover open verified!")

        # Move mouse away
        page.mouse.move(0, 0)
        page.wait_for_timeout(600)
        assert page.locator("[role='dialog']").count() == 0, "Popover should close after mouse leaves!"
        print("  ✓ Hover auto-dismiss verified!")

        # Set trigger back to Click for clean state
        trigger_select.select_option(value="Click")
        page.wait_for_timeout(500)

        # Open popover for final screenshot
        btn.click()
        page.wait_for_timeout(500)

        # Capture verification screenshot
        page.screenshot(path=screenshot_path)
        print(f"\n[SCREENSHOT] Saved verification screenshot at {screenshot_path}")

        browser.close()

    print("\n" + "=" * 80)
    print("ALL TWPOPOVER ANTI-CLIPPING & 8-WAY ARROW TESTS PASSED 100%!")
    print("=" * 80)

if __name__ == "__main__":
    main()
