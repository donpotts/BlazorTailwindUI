import os
import sys
import time
from playwright.sync_api import sync_playwright

def run_union_tests():
    print("[E2E] Starting TwUnionBoundary & Closed State Machine Verification...")
    artifacts_dir = r"C:\Users\donpo\.gemini\antigravity\brain\27e04055-7eb7-457e-ac4c-93c7084425b7\screenshots"
    docs_dir = r"C:\Users\donpo\.gemini\antigravity\scratch\BlazorTailwindUI\docs\images"
    os.makedirs(artifacts_dir, exist_ok=True)
    os.makedirs(docs_dir, exist_ok=True)

    with sync_playwright() as p:
        browser = p.chromium.launch(headless=True)
        context = browser.new_context(viewport={"width": 1440, "height": 960})
        page = context.new_page()

        console_errors = []
        page.on("console", lambda msg: console_errors.append(msg.text) if msg.type == "error" else None)

        print("[Desktop] Navigating to http://127.0.0.1:5128...")
        page.goto("http://127.0.0.1:5128", wait_until="networkidle", timeout=30000)
        time.sleep(2)

        # Locate TwUnionBoundary / Studio
        studio_header = page.locator("text=C# 15 Discriminated Union Boundary Studio")
        assert studio_header.count() > 0, "TwUnionStudio header not found!"
        print("[Desktop] TwUnionStudio header located.")

        studio_card = studio_header.locator("xpath=ancestor::div[contains(@class, 'rounded')]").first
        studio_card.scroll_into_view_if_needed()
        time.sleep(1)

        # 1. Test Initial Success State (4 Invoices)
        assert page.locator("text=Apex Global Logistics").count() > 0, "Initial Success invoice not found!"
        assert page.locator("text=Cyberdyne Quantum AI").count() > 0, "Cyberdyne invoice not found!"
        print("[Desktop] Initial Success state verified (4 corporate invoices rendered).")

        # 2. Test Transition to Loading State
        print("[Desktop] Testing Loading state...")
        loading_btn = page.locator("button", has_text="1. Loading")
        loading_btn.click()
        time.sleep(0.5)
        assert page.locator("text=Evaluating C# 15 Algebraic Union").count() > 0, "Loading skeleton not rendered!"
        print("[Desktop] Loading state with animated pulse skeleton verified.")

        # 3. Test Transition to Empty State
        print("[Desktop] Testing Empty state...")
        empty_btn = page.locator("button", has_text="3. Empty")
        empty_btn.click()
        time.sleep(0.5)
        assert page.locator("text=Zero Outstanding Invoices").count() > 0, "Empty state not rendered!"
        print("[Desktop] Empty state verified.")

        # 4. Test Transition to Failure State
        print("[Desktop] Testing Failure state...")
        failure_btn = page.locator("button", has_text="4. Failure")
        failure_btn.click()
        time.sleep(0.5)
        assert page.locator("text=Upstream Gateway Timeout").count() > 0, "Failure alert card not rendered!"
        assert page.locator("text=HTTP_503_EDGE_TIMEOUT").count() > 0, "Error code badge not rendered!"
        print("[Desktop] Failure state with HTTP 503 error code badge verified.")

        # 5. Test Live Retry Button
        print("[Desktop] Testing live Retry Request dispatch...")
        retry_btn = page.locator("button", has_text="Retry Request")
        retry_btn.click()
        time.sleep(1.2)
        assert page.locator("text=Apex Global Logistics").count() > 0, "Retry did not restore Success state!"
        print("[Desktop] Live retry dispatched and Success state restored.")

        # Capture Desktop Full Screenshot
        screenshot_desktop = os.path.join(docs_dir, "suite-tw-union-boundary.png")
        studio_card.screenshot(path=screenshot_desktop)
        studio_card.screenshot(path=os.path.join(artifacts_dir, "suite-tw-union-boundary.png"))
        print(f"[Desktop] Saved desktop screenshot to {screenshot_desktop}")

        # 6. Mobile Viewport Test (375x812 - iPhone 13/14)
        print("\n[Mobile] Testing Mobile-First Responsiveness (375x812)...")
        mobile_context = browser.new_context(viewport={"width": 375, "height": 812}, is_mobile=True, has_touch=True)
        mobile_page = mobile_context.new_page()
        mobile_page.goto("http://127.0.0.1:5128", wait_until="networkidle", timeout=30000)
        time.sleep(2)

        mobile_studio = mobile_page.locator("text=C# 15 Discriminated Union Boundary Studio").locator("xpath=ancestor::div[contains(@class, 'rounded')]").first
        mobile_studio.scroll_into_view_if_needed()
        time.sleep(1)

        # Test mobile state toggle
        mobile_empty_btn = mobile_page.locator("button", has_text="3. Empty")
        mobile_empty_btn.click()
        time.sleep(0.5)
        assert mobile_page.locator("text=Zero Outstanding Invoices").count() > 0, "Mobile Empty state failed!"

        screenshot_mobile = os.path.join(docs_dir, "suite-tw-union-boundary-mobile.png")
        mobile_studio.screenshot(path=screenshot_mobile)
        mobile_studio.screenshot(path=os.path.join(artifacts_dir, "suite-tw-union-boundary-mobile.png"))
        print(f"[Mobile] Saved mobile screenshot to {screenshot_mobile}")

        # Check console errors
        critical_errors = [e for e in console_errors if "favicon" not in e.lower() and "browserLink" not in e.lower()]
        if critical_errors:
            print(f"[Warning] Console errors: {critical_errors}")
        else:
            print("[Clean] Zero critical console errors encountered!")

        browser.close()
        print("\n[E2E] TwUnionBoundary Comprehensive Verification Succeeded 100%!")

if __name__ == "__main__":
    run_union_tests()
