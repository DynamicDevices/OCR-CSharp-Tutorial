// C# Code Editor and Execution
window.codeEditor = {
    editors: {},
    
    // Initialize Monaco Editor
    initializeEditor: function(containerId, initialCode, readOnly = false) {
        return new Promise((resolve) => {
            require.config({ paths: { vs: 'https://unpkg.com/monaco-editor@0.44.0/min/vs' } });
            require(['vs/editor/editor.main'], function () {
                const editor = monaco.editor.create(document.getElementById(containerId), {
                    value: initialCode,
                    language: 'csharp',
                    theme: 'vs-dark',
                    readOnly: readOnly,
                    minimap: { enabled: false },
                    fontSize: 14,
                    lineNumbers: 'on',
                    roundedSelection: false,
                    scrollBeyondLastLine: false,
                    automaticLayout: true,
                    wordWrap: 'on'
                });
                
                window.codeEditor.editors[containerId] = editor;
                resolve(editor);
            });
        });
    },
    
    // Get code from editor
    getCode: function(containerId) {
        const editor = window.codeEditor.editors[containerId];
        return editor ? editor.getValue() : '';
    },
    
    // Set code in editor
    setCode: function(containerId, code) {
        const editor = window.codeEditor.editors[containerId];
        if (editor) {
            editor.setValue(code);
        }
    },
    
    // Execute C# code (simulated - in a real implementation you'd need a backend service)
    executeCode: function(code) {
        return new Promise((resolve) => {
            try {
                // This is a simplified simulation of C# execution
                // In a real implementation, you'd send this to a backend service
                const output = window.codeEditor.simulateCSharpExecution(code);
                resolve({ success: true, output: output });
            } catch (error) {
                resolve({ success: false, error: error.message });
            }
        });
    },
    
    // Simulate C# code execution for common patterns
    simulateCSharpExecution: function(code) {
        const output = [];
        
        try {
            // Extract Console.WriteLine statements
            const writeLineRegex = /Console\.WriteLine\s*\(\s*([^)]+)\s*\)/g;
            let match;
            
            while ((match = writeLineRegex.exec(code)) !== null) {
                let content = match[1].trim();
                
                // Handle string literals
                if (content.startsWith('"') && content.endsWith('"')) {
                    output.push(content.slice(1, -1));
                }
                // Handle string interpolation (simplified)
                else if (content.startsWith('$"') && content.endsWith('"')) {
                    let interpolated = content.slice(2, -1);
                    
                    // Simple variable substitution for common cases
                    interpolated = interpolated.replace(/\{(\w+)\}/g, (match, varName) => {
                        // Extract variable values from code (simplified)
                        const varRegex = new RegExp(`(int|string|double|bool)\\s+${varName}\\s*=\\s*([^;]+);`);
                        const varMatch = code.match(varRegex);
                        if (varMatch) {
                            let value = varMatch[2].trim();
                            if (value.startsWith('"') && value.endsWith('"')) {
                                return value.slice(1, -1);
                            }
                            return value;
                        }
                        return varName;
                    });
                    
                    output.push(interpolated);
                }
                // Handle simple expressions
                else {
                    // Try to evaluate simple math expressions
                    try {
                        // Only allow safe mathematical operations
                        if (/^[\d\s+\-*/.()]+$/.test(content)) {
                            const result = eval(content);
                            output.push(result.toString());
                        } else {
                            output.push(content);
                        }
                    } catch {
                        output.push(content);
                    }
                }
            }
            
            // If no Console.WriteLine found, provide helpful message
            if (output.length === 0) {
                if (code.includes('Console.WriteLine')) {
                    output.push('Code contains Console.WriteLine but couldn\'t parse output.');
                } else {
                    output.push('No Console.WriteLine statements found. Add some to see output!');
                }
            }
            
        } catch (error) {
            output.push(`Error: ${error.message}`);
        }
        
        return output;
    },
    
    // Resize editor
    resizeEditor: function(containerId) {
        const editor = window.codeEditor.editors[containerId];
        if (editor) {
            editor.layout();
        }
    },
    
    // Dispose editor
    disposeEditor: function(containerId) {
        const editor = window.codeEditor.editors[containerId];
        if (editor) {
            editor.dispose();
            delete window.codeEditor.editors[containerId];
        }
    }
};
