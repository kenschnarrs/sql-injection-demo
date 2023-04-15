import {useState} from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import axios from 'axios';

function App() {

  const [vulnState, setVulnState] = useState("");
  const [secureState, setSecureState] = useState("");

  const initData: Array<string> = []
  const [data, setData] = useState(initData)

  function handleVulnSubmit(){
    console.log(vulnState);
    axios.get('http://localhost:5211/Vulnerable', {params: {username: vulnState}, headers:{"Access-Control-Allow-Origin": "*"}})
    .then(response => {
      //console.log(response.data);
      var data: Array<string> = []
      response.data.forEach((element: string) => {
        if (element != null){
          data.push(element);
        }
      });
      setData(data);
      console.log(data);
    })
    .catch(error => {
      console.log(error);
    });
  }
  
  function handleSecureSubmit(){
    console.log(vulnState);
    axios.get('http://localhost:5211/Secure', {params: {username: secureState}, headers:{"Access-Control-Allow-Origin": "*"}})
    .then(response => {
      var data: Array<string> = []
      response.data.forEach((element: string) => {
        if (element != null){
          data.push(element);
        }
      });
      setData(data);
      console.log(data);
    })
    .catch(error => {
      console.log(error);
    });
  }

  function handleResetSubmit(){
    console.log(vulnState);
    axios.get('http://localhost:5211/Reset', {headers:{"Access-Control-Allow-Origin": "*"}})
    .then(response => {})
    .catch(error => {
      console.log(error);
    });
  }
  return (
    <div className="App">
      <header>
      </header>
      <body>
        <Container fluid>
          <Row>
            <Col md={{ span: 6, offset: 3 }}>
              <br></br>
              <h1>SQL Injection Demonstration Interface
                <br></br>
                <br></br>
              </h1>
            </Col>
          </Row>
          <Row >
            <Col md={{ span: 4, offset: 2 }}>
            <h3>Instructions for Scenario 1</h3>
              <p>1. Insert the text <br></br><b>s'; DROP TABLE t1; SELECT un FROM APP_USERS WHERE un='s</b><br></br>into the user input box.
              <br></br>2. Click submit.
              <br></br>3. The database table "t1" has now been dropped.
              </p>
              <p>
                There are 5 tables, all with the naming conventions tx (i.e., t1, t2, ...etc.). You can thus drop 5 different tables. 
              </p>
              <h3><br></br>Instructions for Scenario 2</h3>
              <p>1. Insert the text <br></br><b>' OR 'x'='x</b><br></br> into the user input box.
                <br></br>2. View that all users have been returned, rather than just 1 or 0.
              </p>
            </Col>
            <Col md={{ span: 3, offset: 1 }}>
              <h3>Regenerate Tables</h3>
              <p>Use this button to regenerate the tables and reset the application.</p>
              <Button onClick={handleResetSubmit}>Regenerate</Button>
              <br></br>
              <br></br>
              <div>
              <h3>Resulting User</h3>
              <p>Below the resulting user will appear when entering an exact name into the username textbox.
                However, we can manipulate what users will appear via the above SQL injection scenarios. An example
                intended user input is "<b>a@gmail.com</b>" (no quotes), which would yield an exact match and display the
                matched username back to you.
              </p>
              {data.map(dataItem => <div key={dataItem}> {dataItem} </div>)}
              </div>
            </Col>
          </Row>
          <Row>
            <Col md={{ span: 6, offset: 3 }}>
                <Form>
                  <br></br>
                  <br></br>
                  <Form.Group className="mb-3" controlId="formBasicEmail">
                    <Form.Label>Vulnerable User Input (exact username match)</Form.Label>
                    <Form.Control type="input" placeholder="Enter username" value={vulnState} onChange={e => setVulnState(e.target.value)}/>
                  </Form.Group>
                  
                  <Button variant="primary" onClick={handleVulnSubmit}>
                      Get Users 
                  </Button>
                  <br></br>
                  <br></br>

                  <Form.Group className="mb-3" controlId="formBasicEmail">
                    <Form.Label>Secure User Input (exact username match)</Form.Label>
                    <Form.Control type="input" placeholder="Enter username" value={secureState} onChange={e => setSecureState(e.target.value)}/>
                  </Form.Group>
                  
                  <Button variant="primary" onClick={handleSecureSubmit}>
                      Get Users 
                  </Button>
                </Form>
            </Col>
          </Row>
        </Container>
        <br></br>
       
        
        
      </body>
    </div>
  );
}

export default App;
