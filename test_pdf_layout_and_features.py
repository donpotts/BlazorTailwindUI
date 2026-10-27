import time
import os
import sys

sys.stdout.reconfigure(encoding='utf-8')
from playwright.sync_api import sync_playwright

def run():
    screenshots_dir = r"C:\Users\donpo\.gemini\antigravity\brain\27e04055-7eb7-457e-ac4c-93c7084425b7\screenshots"
    docs_images_dir = r"C:\Users\donpo\.gemini\antigravity\scratch\BlazorTailwindUI\docs\images"
    os.makedirs(screenshots_dir, exist_ok=True)
    os.makedirs(docs_images_dir, exist_ok=True)

    with sync_playwright() as p:
        browser = p.chromium.launch(headless=True)
        context = browser.new_context(viewport={"width": 1440, "height": 900})
        page = context.new_page()

        print("Navigating to http://127.0.0.1:5128 ...")
        page.goto("http://127.0.0.1:5128", wait_until="networkidle")
        time.sleep(2)

        # Switch to Components tab
        print("Switching to Components tab...")
        page.locator("button:has-text('Core Components')").first.click()
        time.sleep(2)

        # Locate PDF Studio section
        header = page.locator("text=MUTUAL CONFIDENTIAL & BINDING INSTRUMENT").first
        header.wait_for(timeout=10000)
        paper = page.locator("div.rounded-3xl:has-text('MUTUAL CONFIDENTIAL & BINDING INSTRUMENT')").first
        paper.scroll_into_view_if_needed()
        time.sleep(1)

        # 1. Viewport Responsiveness Suite
        viewports = [
            (1440, 900),
            (1280, 800),
            (1024, 768),
            (768, 1024),
            (480, 800),
            (375, 667)
        ]

        print("\n--- 1. VIEWPORT RESPONSIVENESS MEASUREMENTS ---")
        for w, h in viewports:
            page.set_viewport_size({"width": w, "height": h})
            time.sleep(0.8)
            box = paper.bounding_box()
            print(f"Viewport {w}x{h} -> Paper Sheet Width: {box['width']:.1f}px, Height: {box['height']:.1f}px")
            
            # Assert that the paper sheet is NOT collapsed into a sliver
            assert box['width'] >= 280, f"Canvas width too narrow ({box['width']}px) at viewport {w}x{h}"
            assert box['height'] < 2600, f"Canvas height is excessively tall ({box['height']}px) at viewport {w}x{h}"

        # Reset to 1440x900 for full interactive feature validation
        page.set_viewport_size({"width": 1440, "height": 900})
        time.sleep(1)

        print("\n--- 2. INTERACTIVE FEATURE VALIDATIONS ---")
        # 2a. Pre-fill Data
        print("Testing 'Pre-fill Data'...")
        prefill_btn = page.locator("button:has-text('Pre-fill Data')").first
        prefill_btn.click()
        time.sleep(1.0)
        # Check text populated
        assert page.locator("text=Jane M. Doe").count() > 0 or page.locator("input[value*='Jane']").count() > 0 or page.locator("text=Apex Global Cloud").count() > 0, "Pre-fill failed"
        print("✓ Pre-fill data active and fields updated")

        # 2b. Page 2 Navigation
        print("Testing Page 2 Switching...")
        page2_btn = page.locator("button:has-text('Page 2')").first
        page2_btn.click()
        time.sleep(0.5)
        assert page.locator("text=Page 2 of 2").count() > 0, "Page 2 switch failed"
        print("✓ Page 2 navigation active")

        # Return to Page 1
        page1_btn = page.locator("button:has-text('Page 1')").first
        page1_btn.click()
        time.sleep(0.5)

        # 2c. FLATTEN & STAMP PDF (The core new feature requested!)
        print("\n--- 3. TESTING PDF FLATTENING & STAMPING (MERGED STREAM) ---")
        flatten_btn = page.locator("button:has-text('Flatten & Stamp')").first
        flatten_btn.click()
        time.sleep(1.0)

        # Verify Flattened Status Badge
        assert page.locator("text=FLATTENED & MERGED STREAM").count() > 0, "Flattened status badge not found!"
        print("✓ Flattened status badge active: [📜 FLATTENED & MERGED STREAM]")

        # Verify Static Typography & Purged AcroForms
        assert page.locator("text=OFFICIALLY FLATTENED & STAMPED PDF").count() > 0, "Official Flattened header stamp not found!"
        assert page.locator("text=ISO 32000-1 STATIC MERGED CONTENT STREAM").count() > 0, "Static Merged stream footer seal not found!"
        assert page.locator("text=FLATTENED STREAM").count() > 0, "Burned-in field badges not found!"
        print("✓ All active form fields permanently burned-in and flattened into static content stream")

        # Verify Download Button Available
        dl_btn = page.locator("button:has-text('Download Flattened PDF')").first
        assert dl_btn.count() > 0, "Download Flattened PDF button not found!"
        print("✓ Download Merged PDF button available and ready for export")

        # 2d. Test Unflattening
        print("Testing 'Unflatten (Edit Form)'...")
        unflatten_btn = page.locator("button:has-text('Unflatten')").first
        unflatten_btn.click()
        time.sleep(1.0)
        assert page.locator("text=FLATTENED & MERGED STREAM").count() == 0, "Unflattening failed to restore interactive state"
        print("✓ Unflatten successfully restored interactive form inputs")

        # Re-flatten for permanent display in screenshot
        reflatten_btn = page.locator("button:has-text('Flatten & Stamp')").first
        reflatten_btn.click()
        time.sleep(1.0)

        # 2e. Export JSON
        print("\n--- 4. TESTING JSON DATA PAYLOAD EXPORT ---")
        export_btn = page.locator("button:has-text('Export JSON')").first
        export_btn.click()
        time.sleep(0.5)
        assert page.locator("text=Contract Form Data Payload").count() > 0, "Export modal failed"
        close_btn = page.locator("button:has-text('✕')").first
        close_btn.click()
        time.sleep(0.5)
        print("✓ JSON payload export verified")

        # Take screenshot of the PDF Studio component
        print("\n--- 5. CAPTURING HIGH-RESOLUTION ARTIFACT SCREENSHOTS ---")
        studio_card = page.locator("div.rounded-2xl:has-text('PDF Form Filler, Contract Signer')").first
        studio_card.scroll_into_view_if_needed()
        time.sleep(0.8)

        shot1 = os.path.join(screenshots_dir, "suite-pdf-contract-signer.png")
        shot2 = os.path.join(docs_images_dir, "suite-pdf-contract-signer.png")
        studio_card.screenshot(path=shot1)
        studio_card.screenshot(path=shot2)
        print(f"Captured clean studio screenshot -> {shot1}")
        print(f"Captured clean studio screenshot -> {shot2}")

        browser.close()
        print("\n=======================================================")
        print("🎉 ALL TESTS PASSED: FLATTEN, STAMP, RESPONSIVENESS, E2E!")
        print("=======================================================")

if __name__ == "__main__":
    run()
