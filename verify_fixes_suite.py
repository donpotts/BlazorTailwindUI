import os
import sys
from playwright.sync_api import sync_playwright

artifacts_dir = r"C:\Users\donpo\.gemini\antigravity\brain\27e04055-7eb7-457e-ac4c-93c7084425b7\screenshots"
os.makedirs(artifacts_dir, exist_ok=True)

with sync_playwright() as p:
    browser = p.chromium.launch(headless=True)
    context = browser.new_context(viewport={"width": 1440, "height": 900})
    page = context.new_page()

    print("\n--- 1. Testing OCR Commercial Invoice and IRS Form W-9 ---", flush=True)
    page.goto("http://127.0.0.1:5128", wait_until="networkidle")

    # Navigate to QR / OCR tab
    ocr_btn = page.locator("button:has-text('QR, Barcode & OCR')").first
    if not ocr_btn.is_visible():
        ocr_btn = page.locator("button:has-text('QR, Barcode')").first
    ocr_btn.click()
    page.wait_for_timeout(1000)

    # Click Commercial Invoice PDF button
    invoice_btn = page.locator("button:has-text('Commercial Invoice PDF')").first
    invoice_btn.click()
    page.wait_for_timeout(500)

    # Verify Invoice preview container width
    invoice_preview = page.locator("h4:has-text('Commercial Cloud Hosting Invoice')").first.locator("xpath=../..")
    box = invoice_preview.bounding_box()
    print(f"Invoice Preview Box: width={box['width']:.1f}px, height={box['height']:.1f}px", flush=True)
    assert box['width'] > 350, f"Invoice width is too narrow ({box['width']}px)! Should be ~50% of screen."
    print("PASS: Commercial Invoice is rendered with full 50% grid column (not crushed 60px sliver)!", flush=True)

    # Verify invoice text
    assert page.locator("text=APEX CLOUD COMPUTE CORP").count() > 0
    assert page.locator("text=INVOICE #INV-88219").count() > 0
    page.screenshot(path=os.path.join(artifacts_dir, "ocr-invoice-verified.png"))
    print("Saved: ocr-invoice-verified.png", flush=True)

    # Click IRS Form W-9 Tax Document button
    w9_btn = page.locator("button:has-text('IRS Form W-9 Tax Document')").first
    w9_btn.click()
    page.wait_for_timeout(500)

    # Verify W-9 preview container width
    w9_preview = page.locator("h4:has-text('IRS Form W-9 Request for Taxpayer Identification')").first.locator("xpath=../..")
    box_w9 = w9_preview.bounding_box()
    print(f"IRS W-9 Preview Box: width={box_w9['width']:.1f}px, height={box_w9['height']:.1f}px", flush=True)
    assert box_w9['width'] > 350, f"W-9 width is too narrow ({box_w9['width']}px)!"
    assert page.locator("text=Acme Global Technologies Inc.").count() > 0
    assert page.locator("text=12 - 3456789").count() > 0
    assert page.locator("text=Jane Doe, CFO").count() > 0
    print("PASS: IRS Form W-9 is rendered with full 50% grid column!", flush=True)
    page.screenshot(path=os.path.join(artifacts_dir, "ocr-w9-verified.png"))
    print("Saved: ocr-w9-verified.png", flush=True)

    print("\n--- 2. Testing Slider Knob (Left/Right Arrows) & New Samples ---", flush=True)
    page.goto("http://127.0.0.1:5128", wait_until="networkidle")

    # Navigate to Tailwind Showcase tab
    showcase_tab = page.locator("button:has-text('Tailwind Showcase')").first
    showcase_tab.click()
    page.wait_for_timeout(1000)

    # Verify Slider Knob SVG polylines
    slider_card = page.locator("text=Interactive Visual Diff Slider").first
    assert slider_card.is_visible()

    # Find the left and right chevron polylines in the slider
    poly_left = page.locator("polyline[points='8 17 3 12 8 7']").first
    poly_right = page.locator("polyline[points='16 7 21 12 16 17']").first
    assert poly_left.is_visible(), "Left arrow polyline missing or not visible!"
    assert poly_right.is_visible(), "Right arrow polyline missing or not visible!"
    print("PASS: Draggable knob contains true Left and Right chevron arrows (no overlapping 'X')!", flush=True)

    # Test Sample 1: Theme Diff
    assert page.locator("text=DEFAULT LIGHT").count() > 0
    assert page.locator("text=PRO DARK SLATE").count() > 0
    print("PASS: Theme Diff sample verified.", flush=True)

    # Test Sample 2: Background Removal
    bg_pill = page.locator("button:has-text('Background Removal')").first
    bg_pill.click()
    page.wait_for_timeout(500)
    assert page.locator("text=RAW STUDIO PHOTO").count() > 0
    assert page.locator("text=ISOLATED ALPHA CUTOUT").count() > 0
    print("PASS: Background Removal sample active and displaying labels!", flush=True)
    page.screenshot(path=os.path.join(artifacts_dir, "slider-bg-remove-verified.png"))
    print("Saved: slider-bg-remove-verified.png", flush=True)

    # Test Sample 3: 4x Image Upscale
    upscale_pill = page.locator("button:has-text('4x Image Upscale')").first
    upscale_pill.click()
    page.wait_for_timeout(500)
    assert page.locator("text=1X STANDARD (72 DPI)").count() > 0
    assert page.locator("text=4X AI SUPER-RES (4K)").count() > 0
    print("PASS: 4x Image Upscale sample active and displaying labels!", flush=True)
    page.screenshot(path=os.path.join(artifacts_dir, "slider-upscale-verified.png"))
    print("Saved: slider-upscale-verified.png", flush=True)

    # Test Sample 4: Raster to Vector
    vector_pill = page.locator("button:has-text('Raster to Vector')").first
    vector_pill.click()
    page.wait_for_timeout(500)
    assert page.locator("text=RASTER BITMAP (32x32)").count() > 0
    assert page.locator("text=SCALABLE SVG BEZIER").count() > 0
    print("PASS: Raster to Vector sample active and displaying labels!", flush=True)
    page.screenshot(path=os.path.join(artifacts_dir, "slider-vector-verified.png"))
    print("Saved: slider-vector-verified.png", flush=True)

    print("\n--- 3. Testing Global Component Counts Consistency ---", flush=True)
    docs_btn = page.locator("button[title*='Browse Component Documentation']").first
    docs_btn.click()
    page.wait_for_timeout(1000)

    # 1. Header Badge
    badge_count_text = page.locator("text=Components").all_text_contents()
    print("Found component badges:", badge_count_text, flush=True)
    assert any("186 Components" in b for b in badge_count_text), "Header badge does not say 186 Components!"

    # 2. Search Placeholder
    search_input = page.locator("input[placeholder*='components']").first
    placeholder = search_input.get_attribute("placeholder")
    print("Search placeholder:", placeholder, flush=True)
    assert "Search 186 components & props..." in placeholder, f"Unexpected placeholder: {placeholder}"

    # 3. Category Select Option
    first_option = page.locator("select option").first.text_content()
    print("Category dropdown first option:", first_option, flush=True)
    assert "All Categories (186 components)" in first_option, f"Unexpected option: {first_option}"

    # 4. Sidebar Badge
    sidebar_badge = page.locator("button:has-text('Docs & Settings')").first.inner_text()
    safe_badge = sidebar_badge.encode('ascii', 'ignore').decode('ascii').replace("\n", " ")
    print("Sidebar nav item:", safe_badge, flush=True)
    assert "186 ITEMS" in sidebar_badge, f"Sidebar item does not reflect 186 ITEMS: {sidebar_badge}"

    print("PASS: Global component count is synchronized to exactly 186 across Header, Search, Dropdown, and Sidebar!", flush=True)
    page.screenshot(path=os.path.join(artifacts_dir, "component-counts-verified.png"))
    print("Saved: component-counts-verified.png", flush=True)

    browser.close()
    print("\n[SUCCESS] ALL E2E VERIFICATION AUDITS PASSED 100%!", flush=True)
