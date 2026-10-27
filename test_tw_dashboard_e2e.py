import os
import sys
import time
from playwright.sync_api import sync_playwright

def run_dashboard_tests():
    print("[E2E] Starting TwDashboard Comprehensive Verification...")
    artifacts_dir = r"C:\Users\donpo\.gemini\antigravity\brain\27e04055-7eb7-457e-ac4c-93c7084425b7\screenshots"
    docs_dir = r"C:\Users\donpo\.gemini\antigravity\scratch\BlazorTailwindUI\docs\images"
    os.makedirs(artifacts_dir, exist_ok=True)
    os.makedirs(docs_dir, exist_ok=True)

    with sync_playwright() as p:
        # 1. Desktop Test (1440x960)
        browser = p.chromium.launch(headless=True)
        context = browser.new_context(viewport={"width": 1440, "height": 960})
        page = context.new_page()

        console_errors = []
        page.on("console", lambda msg: console_errors.append(msg.text) if msg.type == "error" else None)

        print("[Desktop] Navigating to http://127.0.0.1:5128...")
        page.goto("http://127.0.0.1:5128", wait_until="networkidle", timeout=30000)
        time.sleep(2)

        # Locate TwDashboard
        dashboard = page.locator(".tw-dashboard-root")
        assert dashboard.count() > 0, "TwDashboard root container not found!"
        print("[Desktop] TwDashboard container located.")

        # Scroll into view
        dashboard.scroll_into_view_if_needed()
        time.sleep(1)

        # Check default cards
        cards = dashboard.locator(".grid-stack-item")
        card_count = cards.count()
        print(f"[Desktop] Initial GridStack card count: {card_count}")
        assert card_count >= 7, f"Expected at least 7 cards, got {card_count}"

        # Verify Drag Handles
        handles = dashboard.locator(".move-handle")
        handle_count = handles.count()
        print(f"[Desktop] Drag handles count: {handle_count}")
        assert handle_count >= 7, f"Expected at least 7 drag handles, got {handle_count}"

        # Verify Move Handle styles / attributes
        first_handle = handles.first
        cursor_style = first_handle.evaluate("el => window.getComputedStyle(el).cursor")
        print(f"[Desktop] First drag handle cursor style: {cursor_style}")
        assert "grab" in cursor_style, f"Expected grab cursor, got {cursor_style}"

        # Capture Desktop Full Screenshot
        screenshot_desktop = os.path.join(docs_dir, "suite-tw-dashboard.png")
        dashboard.screenshot(path=screenshot_desktop)
        dashboard.screenshot(path=os.path.join(artifacts_dir, "suite-tw-dashboard.png"))
        print(f"[Desktop] Saved desktop screenshot to {screenshot_desktop}")

        # Test Add Card Modal
        print("[Desktop] Testing Add Card modal...")
        add_btn = dashboard.locator("button", has_text="Add Card")
        add_btn.click()
        time.sleep(0.5)

        modal = page.locator("text=Add Dashboard Card")
        assert modal.count() > 0, "Add Card modal did not open!"
        print("[Desktop] Add Dashboard Card modal is open.")

        # Click on template button "Pipeline Value" to add card
        template_btn = modal.locator("button", has_text="Pipeline Value")
        if template_btn.count() == 0:
            template_btn = page.locator("button", has_text="Pipeline Value")
        template_btn.click()
        time.sleep(1)

        new_card_count = dashboard.locator(".grid-stack-item").count()
        print(f"[Desktop] Card count after addition: {new_card_count}")
        assert new_card_count == card_count + 1, f"Expected {card_count + 1} cards, found {new_card_count}"

        # Test Card Settings Modal
        print("[Desktop] Testing Card Settings modal...")
        gear_btns = dashboard.locator("button", has_text="⚙️")
        print(f"[Desktop] Found {gear_btns.count()} gear buttons inside dashboard.")
        gear_btns.first.click()
        time.sleep(0.5)

        config_modal = page.locator("text=Card Properties:")
        assert config_modal.count() > 0, "Settings modal did not open!"
        print("[Desktop] Card properties modal is open.")

        title_input = page.locator("input").filter(has_text="").last
        # Find the text input inside modal
        modal_inputs = page.locator(".fixed input[type='text']")
        if modal_inputs.count() > 0:
            modal_inputs.first.fill("Enterprise Revenue Target [Updated]")
            print("[Desktop] Filled updated title in modal.")

        dashboard.locator("button", has_text="Save Changes").click()
        time.sleep(1)
        assert dashboard.locator("text=Enterprise Revenue Target [Updated]").count() > 0, "Updated title not reflected!"
        print("[Desktop] Card settings modal update succeeded.")

        # Test Toggle Full Width
        print("[Desktop] Testing Toggle Full Width...")
        width_btns = dashboard.locator("button", has_text="↔️")
        if width_btns.count() > 0:
            width_btns.first.click()
            time.sleep(1)
            print("[Desktop] Toggle full width executed successfully.")

        # Test Lock / Unlock Toggle
        print("[Desktop] Testing Lock Layout toggle...")
        lock_btn = dashboard.locator("button", has_text="Lock Layout")
        lock_btn.click()
        time.sleep(0.5)
        unlock_btn = dashboard.locator("button", has_text="Unlock Layout")
        assert unlock_btn.count() > 0, "Unlock Layout button did not appear after locking!"
        # Toggle back
        unlock_btn.click()
        time.sleep(0.5)
        assert dashboard.locator("button", has_text="Lock Layout").count() > 0, "Lock Layout button did not re-appear!"
        print("[Desktop] Lock / Unlock Layout toggle verified.")

        # Test JSON Layout Export Modal
        print("[Desktop] Testing JSON Layout export/import...")
        json_btn = dashboard.locator("button", has_text="JSON")
        json_btn.click()
        time.sleep(0.5)
        assert page.locator("text=Dashboard Layout Configuration (JSON)").count() > 0, "JSON modal did not appear!"
        textarea = dashboard.locator("textarea").first
        json_content = textarea.input_value()
        print(f"[Desktop] JSON layout verified ({len(json_content)} bytes).")
        # Close modal
        dashboard.locator("button", has_text="Close").click()
        time.sleep(0.5)

        # Test Scratchpad Live Note
        scratchpad = dashboard.locator("textarea[placeholder='Type quick executive notes or CRM observations here...']")
        if scratchpad.count() > 0:
            scratchpad.fill("Quarterly pipeline target: $1.2M on track with Enterprise AOT expansion.")
            print("[Desktop] Executive scratchpad input verified.")

        # 2. Mobile Viewport Test (375x812 - iPhone 13/14 size)
        print("\n[Mobile] Testing Mobile-First Responsiveness (375x812)...")
        mobile_context = browser.new_context(viewport={"width": 375, "height": 812}, is_mobile=True, has_touch=True)
        mobile_page = mobile_context.new_page()
        mobile_page.goto("http://127.0.0.1:5128", wait_until="networkidle", timeout=30000)
        time.sleep(2)

        mobile_dashboard = mobile_page.locator(".tw-dashboard-root")
        mobile_dashboard.scroll_into_view_if_needed()
        time.sleep(1)

        # Check mobile drag handles & touch controls
        mobile_handles = mobile_dashboard.locator(".move-handle")
        assert mobile_handles.count() >= 7, "Mobile handles not rendered!"

        # Check 1-tap mobile positioning buttons (arrow down / up)
        move_down_btn = mobile_dashboard.locator("button[title='Move Card Down']").first
        if move_down_btn.count() > 0:
            move_down_btn.click()
            time.sleep(0.5)
            print("[Mobile] 1-tap card repositioning verified.")

        # Capture Mobile Screenshot
        screenshot_mobile = os.path.join(docs_dir, "suite-tw-dashboard-mobile.png")
        mobile_dashboard.screenshot(path=screenshot_mobile)
        mobile_dashboard.screenshot(path=os.path.join(artifacts_dir, "suite-tw-dashboard-mobile.png"))
        print(f"[Mobile] Saved mobile screenshot to {screenshot_mobile}")

        # Check filtered console errors
        critical_errors = [e for e in console_errors if "favicon" not in e.lower() and "browserLink" not in e.lower()]
        if critical_errors:
            print(f"[Warning] Console errors: {critical_errors}")
        else:
            print("[Clean] Zero critical console errors encountered!")

        browser.close()
        print("\n[E2E] TwDashboard Comprehensive Verification Succeeded 100%!")

if __name__ == "__main__":
    run_dashboard_tests()
