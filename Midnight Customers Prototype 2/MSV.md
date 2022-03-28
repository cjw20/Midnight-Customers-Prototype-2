# Modified Semantic Versioning
This document describes the custom versioning scheme used on all Nocturnus Media projects.
This is a variation of the [Semantic Versioning](https://semver.org/) standards.
The biggest differences relate to the addition of the package version, the different definition of what constitutes a change of the major version, and the pre-release label being limited to only "alpha" and "beta".

## Summary
Given a version number Major.Minor.Patch.Package-Label i.e. Version: 2.1.14.3-alpha:
- **Major**: This indicates a major milestone in the game. Increment this when going from alpha to beta, from beta to release, and from release to major updates.
- **Minor**: Increment this for feature updates, large bug fixes, etc.
- **Patch**: Increment this for minor alterations on existing features, small bug fixes, etc.
- **Package**: Increment this when your code stays the same, but external library change or asset files are updated.
- **Label**: This is optional and the only valid labels are "alpha" and "beta".

## Modified Semantic Versioning Specification
1. A normal version MUST take the form W.X.Y.Z where W, X, Y, and Z are non-negative integers, and MUST NOT contain leading zeros. W is the major version, X is the minor version, Y is the patch version, and Z is the package version. Each element MUST increase numerically. For instance: 1.9.0.2 -> 1.10.0.0 -> 1.11.0.0.
2. Once a new version has been built in Unity, a new release MUST be made in GitHub matching the version of the Unity build. If the Unity build is for example "1.2.0.2" then the GitHub release tag should be "v1.2.0.2". The contents of this new version MUST NOT be modified. Any modifications MUST be released as a new version.
3. Major version zero (0.X.Y.Z) is for initial development. Anything MAY change at any time.
4. Version 1.0.0.0 defines the start of the public release. The way in which the version number is incremented after this release is dependent on this public release and how it changes. (Keep in mind the first public release might have a label such as "alpha".
5. Package version Z (w.x.y.Z | w > 0) MUST be incremented if only new assets (artwork, audio, video, models, etc.) are introduced and no code changes have been made.
6. Patch version Y (w.x.Y.z | w > 0) MUST be incremented if only backwards compatible bug fixes are introduced. A bug fix is defined as an internal change that fixes incorrect behavior. Package version MUST be reset to 0 when patch version is incremented.
7. Minor version X (w.X.y.z | w > 0) MUST be incremented if new, backwards compatible functionality is introduced to the public release. It MUST be incremented if any public release functionality is marked as deprecated. Both patch version and package version MUST be reset to 0 when minor version is incremented.
8. Major version W (W.x.y.z | w > 0) MUST be incremented when going from alpha to beta, beta to release, or from release to major updates. Minor, patch, and package versions MUST be reset to 0 when major version is incremented.
9. A pre-release version MAY be denoted by appending a hyphen and a label immediately following the package version. Labels MUST comprise of only the words "alpha" or "beta". Pre-release versions have a lower precedence than the associated normal version. A pre-release version indicates that the version is unstable and might not satisfy the intended compatibility requirements as denoted by its associated normal version. Examples: 1.0.0.0-alpha, 1.2.17.2-beta.
10. Precedence refers to how versions are compared to each other when ordered.
  - Precedence MUST be calculated by separating the version into major, minor, patch, package, and pre-release identifiers in that order.
  - Precedence is determined by the first difference when comparing each of these identifiers from left to right as follows: Major, minor, patch, and package versions are always compared numerically. Exmaple: 1.0.0.0 < 2.0.0.0 < 2.1.0.0 < 2.1.1.1.
  - When major, minor, patch, and package are equal, a pre-release version has lower precedence than a normal version: Example: 1.0.0.0-alpha < 1.0.0.0.
  - Precedence for two pre-release versions with the same major, minor, patch, and package version MUST be determined by comparing each dot separated identifier from left to right until a difference is found. Example: 1.0.0.0-alpha < 1.0.0.0-beta.
