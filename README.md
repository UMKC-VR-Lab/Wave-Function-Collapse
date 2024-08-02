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
Now, going in reverse. Given any arbitrary set of block constraints, can we construct an identical set of face constraints. It will undoubtedly be more verbose than the block constraint, but it is possible.

Hypotheses to test are as follows:
On average does block scope minimize expression length and maximize storage space, and does attribute scope minimize storage space but maximize expression length. This will be evaluated for every possible constraint in a given possibility space.
