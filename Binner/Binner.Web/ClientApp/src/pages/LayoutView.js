import React, {useCallback, useRef, useState, Component } from "react";
import { useNavigate } from "react-router-dom";
import { useTranslation, Trans } from "react-i18next";
import _ from "underscore";
import QuickPinchZoom, { make3dTransformValue } from "react-quick-pinch-zoom";

import "./LayoutView.css";

export function LayoutView(props) {
    const { t } = useTranslation();
    const navigate = useNavigate();

    const layoutCanvas = useRef();

    const onUpdate = useCallback(({ x, y, scale }) => {
        const { current: canvas } = layoutCanvas;
        // check if image exists
        if (canvas) {
            const value = make3dTransformValue({ x, y, scale });
            canvas.style.setProperty("transform", value);
        }
    }, []);


    return (
        <div className="layoutView">
            <QuickPinchZoom onUpdate={onUpdate} doubleTapToggleZoom verticalPadding={100} horizontalPadding={100}>
                <div className="layoutCanvas" ref={layoutCanvas} alt="canvas">
                    <div className="content">uwuuwuuuwu</div>
                </div>
        </QuickPinchZoom>

        </div>
    );
}
