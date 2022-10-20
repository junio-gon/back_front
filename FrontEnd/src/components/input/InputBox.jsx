import React, { PureComponent } from 'react';
import './_input.scss';

export default class InputBox extends PureComponent {
    
    static getDerivedStateFromProps(props, state) {
        if (props.disabled && state.focus)
            return {focus: false};
        
        return null;
    }
    
    state = {
        focus: false
    };

    onFocus = () => this.setState({focus: true});

    onBlur = () => this.setState({focus: false});
    
    onRef = (ref) => this._ref = ref;
    
    get input() {
        return this._ref;
    }
    
    get value() {
        return this._ref.value;
    }

    render() {
        const { label, disabled, ...props } = this.props;
        
        let className = 'input';
        
        if (this.state.focus)
            className += ' focus';
        
        if (disabled)
            className += ' disabled';
        
        return (
            <label className={className} ref={this.onLabelRef}>
                <span>{label}</span>
                <input
                    onFocus={this.onFocus}
                    onBlur={this.onBlur}
                    ref={this.onRef}
                    disabled={disabled}
                    {...props} />
            </label>
        );
    }

}