# Wave Function Collapse
This project aims to delve into the intricacies of the wave function collapse (WFC) algorithm and explore its various aspects, including visualization, traversal algorithms, possibility space data structures, and constraint implementation.

## Project Overview
The wave function collapse algorithm is a constraint-solving technique widely used in procedural generation. Architecture firms, game development studios, and digital media companies employ procedural techniques in their work. This project will explore the algorithm in multiple phases, each focusing on different aspects and experimentation.

## Project Phases
### Phase 1: Visualization Tooling
- Develop visualization tools to represent the wave function collapse process.
- Create interactive interfaces to help understand the algorithm's behavior and outcomes.

### Phase 2: Traversal Algorithm Experimentation
- Experiment with different traversal algorithms, including:
  - Merrell's scanline approach
  - Gumin's heuristic-based approach
  - Depth-first traversal
  - Breadth-first traversal
- Compare and contrast these methods in terms of efficiency and output quality.

### Phase 3: Possibility Space Data Structure Experiments
- Explore various data structures for representing the possibility space:
  - 3D matrix vs. 1D vector
  - Analyze performance implications, focusing on caching benefits.
  - Implement priority queues, particularly effective with Gumin's approach.
  - Use graph representations where each node has a list of adjacent neighbors.

### Phase 4: Constraint Experiments
- Investigate different models for describing constraints:
  - Block Constraints (For each block, a list of blocks which are valid against it)
  - Face Constraints (For each face, a list of faces which are valid against it)
  - Attribute Constraints (For each attribute a list of valid neighbor blocks or faces)
Blocks are composed of faces, and faces are composed of features. Constraints on attributes will have far reaching effects, while block constraints are limited in the scope of the possibility space they will constrain.

A law of this space is that attribute, face, and block constraints are all identically capable of restricting the possibility space. A quick proof is as follows. Take any set of attribute constraints and attempt to describe them with face constraints. This calculation takes time, but it is a simple algorithm which iterates all face pairs and checks them against the attribute constraint and returns true if they are valid otherwise false. The resulting list of valid pairs of faces is an identical constraint but now expressed with face constraints. The same process will take face constraints to block constraints.
Now, going in reverse. Given any arbitrary set of block constraints, can we construct an identical set of face constraints. It will undoubtedly be more verbose than the block constraint. Naively, iterate the set of face constraints and look at the attributes of all faces. Some scenarios may arise which are constraints on combinations of attributes. Since a face constraint could, for example be as follows:
Face A having attributes alpha and beta.
Face B having attributes gamma, and delta.
Face rule invalid: A -> B. 

This face rule would convert to attribute rules: 
invalid: alpha -> gamma 
invalid: alpha -> delta 
invalid: beta -> gamma 
invalid: beta -> delta

Those have no trouble describing the face rule. But given a third face and a second face rule:
Face C having attributes gamma, and epsilon
Face rule valid: A -> C

This face rule produces attribute rules:
valid: alpha -> gamma 
valid: alpha -> epsilon 
valid: beta -> gamma 
valid: beta -> epsilon 

The union of these two sets of attribute rules contains contradictory attribute rules:
invalid: alpha -> gamma
valid: alpha -> gamma
and
invalid: beta -> gamma 
valid: beta -> gamma 

These contradiction may prove that any lower level constraint cannot be expressed as a higher level constraint by direct propagation of observed attributes without omission.
But what if we allow omissions? Does the resulting set of attribute constraints produce a possibility space identically to what the face constraints produce?

Face constraint set:
invalid: A -> B
valid: A -> C 

Attribute constraint set:
2. invalid: alpha -> delta 
4. invalid: beta -> delta
6. valid: alpha -> epsilon 
8. valid: beta -> epsilon 

Testing. 
Does this prohibit A -> B?
Yes. Via attribute rules 2 and 4.

Does this allow A -> C?
Yes. Via attribute rules 6 and 8.

But what if we add a fourth face and a third face rule:
Face D having attributes epsilon and zeta
Face rule invalid: A -> D

This will force us to omit attribute rules 6 and 8, which means the attribute set cannot express the face rules simultaneously.
So, some sets of face rules have more specificity than attribute rules can express.
This is due to the face rule's ability to encode conditional relationships between groups of attributes.
Since a face is a group of objects, and a block is a group of faces, the same is true for block roles to face rules.

A mix of all the rules is likely the most expressive and conscise way to define constraints on a possibility space.
Constraints on attributes, groups of attributes, groups of groups of attributes, ad infinitum.
Contradictions should resolve to abide the constraint of highest specificity.
For instance. 
Given a group of groups of attributes which classify a dog
two groups of attributes from two instances of a dog:
Fido
Lassy
And the group of groups rule 
valid: dog <-> dog
And the group of attributes rule 
invalid: Fido -> Lassy

Meaning that you can put generally put dogs near each other, but you can't put Fido near Lassy.
There is a contradiction which should be delegated to the rule of lowest specificity, I. E.
invalid: Fido -> Lassy

We will test this in our implementation by allowing users to input constraints on attributes, groups of attributes, and groups of groups of attributes and automatically resolving contradictions by following the rule of lowest specificity.
