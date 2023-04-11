import React from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';

function App() {
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
            <h2>Instructions for Scenario 1</h2>
              <p><br></br>1. Insert the text "x; DROP TABLE t1" (without the quotes) into the password input box.
              <br></br>2. Click submit.
              <br></br>3. View in MS SQL Server that a table has been dropped.
              </p>
              <p>
                There are 5 tables, all with the naming conventions tx (i.e., t1, t2, ...etc.).
                <br></br>You can thus drop 5 different tables. Use MS SQL Server to view that tables have
                been dropped. There's also a table for "Users", but I wouldn't drop that one since
                then you wouldn't be able to authenticate.
              </p>
              <h2><br></br>Instructions for Scenario 2</h2>
              <p><br></br>1. Insert the text "x OR True" (without the quotes) into the password input box.
              <br></br>2. View that you have been authenticated.
              </p>
            </Col>
            <Col md={{ span: 3, offset: 1 }}>
                <h2>Regenerate Tables</h2>
                <p>Use this button to regenerate the tables and reset the application.</p>
                <Button>Regenerate</Button>
            </Col>
          </Row>
          <Row>
            
            <Col md={{ span: 6, offset: 3 }}>
                <Form>
                  <br></br>
                  <br></br>
                    <Form.Group className="mb-3" controlId="formBasicEmail">
                      <Form.Label>Email</Form.Label>
                      <Form.Control type="email" placeholder="Enter email" />
                    </Form.Group>

                  <Form.Group className="mb-3" controlId="formBasicPassword">
                      <Form.Label>Password</Form.Label>
                      <Form.Control type="password" placeholder="Password" />
                  </Form.Group>
                  <Button variant="primary" type="submit">
                      Submit
                  </Button>
                  <br></br>
                  <br></br>
                </Form>
            </Col>
          </Row>
        </Container>
        
      </body>
    </div>
  );
}

export default App;
