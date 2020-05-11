import React, { Component } from 'react';
export default class Map extends Component {
  constructor(props){
    super(props)
    this.state = {
      profile : this.props.profile
    }
  }
  async componentDidUpdate(){
    if(this.props.profile !== this.state.profile)
    await this.setState({
      profile: this.props.profile
    })
  }

  render() {
  
    return (
      <div>
          <h1>{this.props.profile.Email}</h1>
       </div>
    );
  }

}
